using System;
namespace TryNUnitTest.Tests
{
	using NUnit.Framework;
	using Moq;

	public interface IProxyTestNextAction
	{
		object wantActionData { get; }
		object ActionInfo { get; }
		object Actor { get; }
		object actorInfo { get; }
		object actorController { get; }
		object CurrActionData { get; }
		object LastActionData { get; }
		void NeedRage();
		bool IsNpcAndBoss();
		void IsStandalone();
		void SyncBattleKey(SyncMaster sm);
		SyncMaster GetSyncMaster();
		Shafts GetOrCreateShafts();
	}

	[TestFixture]
	public class TestNextActionTest
	{
		[Test]
		void TestRun()
		{
			var proxy = Mock<IProxyTestNextAction>();
			proxy.SetupGet(i => i.wantActionData).Returns(new WantActionData());
			proxy.SetupGet(i => i.ActionInfo).Returns(new ActionInfo());
			proxy.SetupGet(i => i.Actor).Returns(new Actor());
			proxy.SetupGet(i => i.actorInfo).Returns(new ActorInfo());
			proxy.SetupGet(i => i.actorController).Returns(new ActorController());
			proxy.SetupGet(i => i.CurrActionData).Returns(new WantActionData());
			proxy.SetupGet(i => i.LastActionData).Returns(new WantActionData());
			proxy.Setup(i => i.NeedRage);
			proxy.Setup(i => i.IsNpcAndBoss).Returns(false);
			proxy.Setup(i => i.IsStandalone).Returns(false);
			proxy.Setup(i => i.SyncBattleKey(null));
			proxy.Setup(i => i.GetSyncMaster).Returns(null);
			proxy.Setup(i => i.GetOrCreateShafts).Returns(new Shafts());

			BattleKeyState bks;
			SkillData skillData = null;
			var result = new TestNextAction(proxy.Object).Run(bks, skillData);

			Assert.AreEquals(111, result);
		}
	}


	public class TestNextAction
	{
		class Proxy : IProxyTestNextAction
		{
			public object wantActionData { get; private set; }

			public object ActionInfo { get; private set; }

			public object Actor { get; private set; }

			public object actorInfo { get; private set; }

			public object actorController { get; private set; }

			public object CurrActionData { get; private set; }

			public object LastActionData { get; private set; }

			void NeedRage()
			{
				if (GameStageManager.Instance != null)
				{
					GameStageManager.Instance.NeedRage();
				}
			}

			bool IsNpcAndBoss()
			{
				if (this.Actor is Npc)
				{
					return (this.Actor as Npc).npc.IsBOSS;
				}
				return false;
			}

			void IsStandalone()
			{
				return Globals.Instance.IsStandalone;
			}

			void SyncBattleKey(SyncMaster sm)
			{
				sm.SyncBattleKey(BattleKeys.Defend, this.actorController.FaceDirection);
			}

			SyncMaster GetSyncMaster()
			{
				return this.GetComponent<SyncMaster>();
			}

			void GetOrCreateShafts()
			{
				//这是一个恶心的操作。换人后又actionInfo，但是没有shafts。需要重新指定一下
				this.ActionInfo.Shafts = ActionConfig.Instance.GetOrCreateShafts(this.currActionData.ActionID);
			}
		}

		readonly IProxyTestNextAction proxy;

		public TestNextAction(IProxyTestNextAction proxy)
		{
			this.proxy = proxy;
		}

		public long Run(BattleKeyState bks, out SkillData skillData)
		{
			skillData = null;
			long actionID = 0;
			if (this.wantActionData != null && bks.Shaft.Priority <= this.wantActionData.Priority)
			{
				return 0;
			}

			if (this.Actor == null || this.ActionInfo == null || this.ActionInfo.Shafts == null)
			{
				this.ActionInfo.Shafts = this.GetOrCreateShafts();

				if (this.ActionInfo.Shafts == null)
				{

#if UNITY_EDITOR
                if (this.ActionInfo == null)
                    GDebug.LogError("ActionInfo Null    " + this.currActionData.ActionID);
                else if (this.ActionInfo.Shafts == null)
                {
                    GDebug.LogError("ActionInfo Shafts null    " + this.currActionData.ActionID);
                    var shafts = ActionConfig.Instance.GetOrCreateShafts(this.currActionData.ActionID);
                    GDebug.LogError((shafts == null) ? "无配置。。" : "有配置");
                }
#endif
					return 0;
				}
			}

			// 如果是受伤动作并且不是受身
			// 		if (this.ActionInfo.Shafts.ActionType == 500 && BattleKeys.AttackSpe4 != bks.Bk)
			// 		{
			// 			return 0;
			// 		}

			// 如果是受身动作不能放技能
			// 		if (this.ActionInfo.ActionID % 1000 == 701)
			// 		{
			// 			return 0;
			// 		}

			actionID = bks.Shaft.NextActionID;
			var errorResult = Actor.GetActionIDByBKErrorResult.None;
			switch (bks.Bk)
			{
				case BattleKeys.AssistShift:
					// 不做处理,如果要用它来做Next,配置NextActionID就可以
					break;

				case BattleKeys.Up:
				case BattleKeys.Down:
				case BattleKeys.Left:
				case BattleKeys.Right:
					actionID = this.actorController.GetButton(BattleKeys.AssistShift)
									? this.actorInfo.BaseAction.ReRun
									: this.actorInfo.BaseAction.Run;
					break;

				case BattleKeys.AttackNor:
					// 是否需要自动继续连招
					if (this.CurrActionData.ActionID == this.actorInfo.BaseAction.Run
						&& Time.time - this.CurrActionData.SwitchSysTime < 0.5f
						&& // CurrActionData.switchSysTime 就是LastActionData.EndSystemTime
					    this.LastActionData != null && this.Actor.InAttackNorTree(this.LastActionData.ActionID))
					{
						// 找到下一个动作ID
						actionID = this.Actor.NextActionByAttackNorTree(this.LastActionData.ActionID, out skillData);
					}

					if (actionID == 0)
					{
						actionID = bks.Shaft.NextActionID == 0 ?
							this.Actor.GetActionIDByBK(bks.Bk, true, true, this.ActionInfo.Shafts.ActionType, ref skillData, ref errorResult) :
							bks.Shaft.NextActionID;
					}

					// 当bks.Shaft.NextActionID不为0的时候，就会跳过查询，做一次修补，尝试再获取一次
					if (actionID != 0 && skillData == null)
					{
						skillData = this.Actor.GetSkillDataByAction(actionID);
					}
					break;

				case BattleKeys.AttackSpe1:
					actionID = this.Actor.GetActionIDByBK(bks.Bk, true, true, this.ActionInfo.Shafts.ActionType, ref skillData, ref errorResult);
					break;
				case BattleKeys.AttackSpe2:
				case BattleKeys.AttackSpe3:
				case BattleKeys.AttackSpe4:
				case BattleKeys.AttackSuper:
					actionID = this.Actor.GetActionIDByBK(bks.Bk, true, true, this.ActionInfo.Shafts.ActionType, ref skillData, ref errorResult);
					break;

				case BattleKeys.DodgeRoll:
				case BattleKeys.EnergyCharge:
				case BattleKeys.Throw:
#if _THDOROENCH_
			case BattleKeys.ThDoRoEnCh:
#endif
					// 尝试查询技能设置，如果有用，就用技能值替换，如果无用，就直接用配置动作
					var tmpActionID = this.Actor.GetActionIDByBK(bks.Bk, true, true, this.ActionInfo.Shafts.ActionType, ref skillData, ref errorResult);
					if (tmpActionID != 0)
					{
						actionID = tmpActionID;
					}
					break;
				//防御是没有动作的,但是buff要执行
				case BattleKeys.Defend:
					actionID = this.Actor.GetActionIDByBK(bks.Bk, true, true, this.ActionInfo.Shafts.ActionType, ref skillData, ref errorResult);
					if (skillData != null)
					{
						if (this.Actor.RunInClient)
							this.Actor.ActiveBuff(TriggerType.Use, skillData.SkillInfo.Buffs, skillData);
						else
						{
							SyncMaster sm = this.GetSyncMaster();
							if (sm != null)
							{
								this.SyncBattleKey(sm);
							}
						}
					}
					break;
			}
#if UNITY_EDITOR && false

        if (errorResult == Actor.GetActionIDByBKErrorResult.CantFindSkillData)
		{
			GDebug.LogWarning(string.Format("GetActionIDByBK: BattleKey={0}, ActionID={1}", bks.Bk, actionID));
        }
        else if (errorResult == Actor.GetActionIDByBKErrorResult.HaveNoPotence)
        {
            GDebug.LogWarning("没有权限释放此技能!!");
        }
        else
#endif
			if (errorResult == Actor.GetActionIDByBKErrorResult.NeedRage)
			{
				// !!!!!!注意，如果按键按着，会一直调用的，做真实界面的时候，优化一下，加个最后一次显示时间，间隔多久才能再次显示。
				if (this.Actor.ActorType == ActorType.Player)
				{
					this.NeedRage();
				}
				// 没力气了，不切这个动作了，不管怎么设置都不切了
				actionID = 0;
			}


			if (this.IsStandalone() && actionID > 0)
			{
				if (this.IsNpcAndBoss() && skillData != null && skillData.SkillInfo.BossIndicatorActionID > 0)
				{
					actionID = skillData.SkillInfo.BossIndicatorActionID;
				}
			}

			return actionID;
		}

}
}
