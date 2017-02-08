using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ClassLibrary1;

namespace ClassLibrary1
{
	using System.Collections.Specialized;
	using System.Threading;

	public class FightingSystem
	{
		public FightingSystem()
		{
		}
	}

	class RequestData
	{

	}

	class PluginInfo
	{
		public string PType;
	}
	class ActionInfo
	{
		public PluginInfo[] Plugins { get; set; }
	}

	public class ShaftBase : IShaftBase
	{
		private bool isEnable;
		public bool IsEnable
		{
			get
			{
				return this.isEnable;
			}
		}

		public void SetEnable(bool enable)
		{
			this.isEnable = enable;
		}

		public bool IsValidRange(float currentTime)
		{
			throw new NotImplementedException();
		}
	}

	class ShaftAttackBox : ShaftBase, IShaftPlugin
	{
		public EventHandler Collided;

		public void OnActionEnd()
		{
			// TODO 根据情况决定改变攻击盒子的状态
		}

		public void OnDisable()
		{
			// TODO 将攻击盒子关闭
		}

		public void OnEnable()
		{
			// TODO 将攻击盒子开启
		}

		public void Run()
		{
			throw new NotImplementedException();
		}

		private void OnCollided()
		{
			// TODO 碰撞之后,将是一个非常复杂的事情,将这个事件传递出去,自己不做什么处理

			//     [内部]  将一些shaft传递添加到碰撞双方

			//     [外部]  技能效果的应用,伤血,改变动作的请求
			//this.action.ActionSystem.AttackBoxCollided(this);

			this.Collided(this, EventArgs.Empty);
		}
	}

	class ShaftAnim : ShaftBase, IShaftPlugin
	{
		public void OnActionEnd()
		{
			throw new NotImplementedException();
		}

		public void OnDisable()
		{
			throw new NotImplementedException();
		}

		public void OnEnable()
		{
			throw new NotImplementedException();
		}

		public void Run()
		{
			// TODO 更新动画播放的位置
		}
	}

	class ShaftEffect : ShaftBase, IShaftPlugin
	{
		public void OnActionEnd()
		{
			// TODO 根据情况决定是否要结束终止特效
		}

		public void OnEnable()
		{
			// TODO 播放特效
		}

		public void OnDisable()
		{
			// TODO 停止特效
		}

		public void Run()
		{
			// TODO 更新特效
		}
	}

	public class ActorAction : IAction, IRun
	{
		public long ActionID { get; private set; }

		public List<IShaftPlugin> Plugins { get; private set; }

		public float CurrentTime { get; private set; }

		public ActionSystem ActionSystem
		{
			get
			{
				return this.actionSystem;
			}
		}

		ActionSystem actionSystem;

		public ActorAction(ActionSystem actionSystem)
		{
			this.actionSystem = actionSystem;
		}

		public void Switch(WantActionData wad)
		{
			this.End();
			this.Reset();
			this.Apply(wad);
		}

		public void Run()
		{
			for (int i = 0; i < this.Plugins.Count; ++i)
			{
				this.PluginRun(this.Plugins[i]);
			}
		}

		private void PluginRun(IShaftPlugin plugin)
		{
			if (plugin.IsValidRange(this.CurrentTime))
			{
				if (!plugin.IsEnable)
				{
					((ShaftBase)plugin).SetEnable(true);
					plugin.OnEnable();
				}

				plugin.Run();
			}
			else
			{
				if (plugin.IsEnable)
				{
					((ShaftBase)plugin).SetEnable(false);
					plugin.OnDisable();
				}
			}
		}

		public void Reset()
		{
			this.Plugins.Clear();
		}

		public void Add(IShaftPlugin plugin)
		{
			throw new NotImplementedException();
		}

		public void Del(IShaftPlugin plugin)
		{
			throw new NotImplementedException();
		}

		private void End()
		{
			for (int i = 0; i < this.Plugins.Count; ++i)
			{
				var plugin = this.Plugins[i];
				plugin.OnActionEnd();
			}
		}

		private void Apply(WantActionData wad)
		{
			ActionInfo ai = this.GetActionInfoBy(wad);

			for (int i = 0; i < ai.Plugins.Length; ++i)
			{
				var plugin = ai.Plugins[i];
				this.Plugins.Add(this.CreatePlugin(plugin));
			}
		}

		private IShaftPlugin CreatePlugin(PluginInfo plugin)
		{
			// TODO 这个函数,可以被拆分成小的类,比如注册方式d
			switch (plugin.PType)
			{
				case "AttackBox":
					var shaft = new ShaftAttackBox();
					// [LINK]连接ShaftAttackBox与AttackBoxCollided
					shaft.Collided = this.ActionSystem.AttackBoxCollision.OnCollided;
					return shaft;
				case "Effect": return new ShaftEffect();
				case "Anim": return new ShaftAnim();
			}
			
			throw new NotImplementedException();
		}

		private ActionInfo GetActionInfoBy(WantActionData wad)
		{
			throw new NotImplementedException();
		}
	}

	public class ActionSystem : IRun, IActionSystem
	{
		public IAction Action { get; private set; }

		public event EventHandler ActionChanged;

		public event EventHandler AttackBoxCollided;

		private AttackBoxCollision attackBoxCollision = new AttackBoxCollision();
		public AttackBoxCollision AttackBoxCollision { get { return this.attackBoxCollision; } }

		public ActionSystem()
		{
			// [LINK]连接ActionSystem与AttackBoxCollision
			this.attackBoxCollision.Collided += (sender, e) => this.AttackBoxCollided(this, e);
		}

		public void SwitchActionImmediately(WantActionData want)
		{
			this.ClearRequests();
			this.SwitchAction(want);
		}

		public void SwitchActionByRule(WantActionData want)
		{
			this.PushRequest(want);
		}

		public long CheckNextAction()
		{
			throw new NotImplementedException();
		}

		public void Run()
		{
			// 切动作的[需求]
			//  输入、网络  转换成为需求
			var requests = this.GetRequests();

			// 能否切的[条件]
			WantActionData wad;
			if (this.CanSwitch(requests, out wad))
			{
				// 切的处理[内部]
				// 切的处理[外部]
				this.SwitchAction(wad);
			}
		}

		private void SwitchAction(WantActionData wad)
		{
			// 切的处理[内部]
			IAction action = this.Action;
			action.Switch(wad);

			// 切的处理[外部]
			A.RaiseEvent(this, this.ActionChanged, EventArgs.Empty);
		}

		private bool CanSwitch(List<RequestData> requests, out WantActionData wad)
		{
			throw new NotImplementedException();
		}

		private List<RequestData> GetRequests()
		{
			throw new NotImplementedException();
		}

		private void PushRequest(WantActionData want)
		{
			throw new NotImplementedException();
		}

		private void ClearRequests()
		{
			throw new NotImplementedException();
		}
	}

	public class AttackBoxCollision
	{
		public event EventHandler Collided;

		public void OnCollided(object sender, EventArgs e)
		{
			// 是有效的碰撞吗？
			if (this.IsValidCollision())
			{
				// 进行各种相关的变化
				this.ApplyConllision();

				this.Collided(this, EventArgs.Empty);
			}
		}

		private void ApplyConllision()
		{
			// TODO 各种东西
			//  变动作（要条件吗？）
			//  变属性（要条件吗？）
			//  加BUFF（要条件吗？）
			//  其它
		}

		private bool IsValidCollision()
		{
			// TODO 攻击盒子所有者-攻击者满足有效碰撞条件？

			// TODO 被攻击盒子碰撞者-被攻击者满足有效碰撞条件？

			return false;
		}
	}

	public class App
	{
		Input input = new Input();
		List<Thread> threads = new List<Thread>();

		private void Enter()
		{
			//new Action().BeginInvoke(this.PlayStage);
			threads.Add(new Thread(() => this.PlayStage()));
		}

		private void Leave()
		{
			this.threads.ForEach((obj) => obj.Abort());
			this.threads.Clear();
		}

		private void Tick()
		{
			this.input.OnInput(EventArgs.Empty);
		}

		public void Run()
		{
			this.Enter();

			this.Tick();

			this.Leave();
		}

		public void PlayStage()
		{
			bool isStageEnd = false;
			Stage stage = new Stage();
			stage.StageEnded += (sender, e) => isStageEnd = true;

			while (!isStageEnd)
			{
				stage.Run();
			}
		}
	}

	public class Input
	{
		public void OnInput(EventArgs e)
		{
			// 可以使用Chain of Responsibility来链接它们

			if (this.IsDebugInput(e))
			{
				
			}
			else if (this.IsUIInput(e))
			{
				
			}
			else if (this.IsActorInput(e))
			{
				this.GetCurActor().OnInput(e);
			}
			else if (this.IsAppInput(e))
			{

			}
			else if (this.IsOtherInput(e))
			{

			}
		}

		Actor GetCurActor()
		{
			throw new NotImplementedException();
		}
	}

	public class Actor : IRun
	{
		public string Name;

		public IActionSystem ActionSystem;

		public void OnInput()
		{
			if (this.IsMove())
				this.Move();
			else if (this.IsSkill())
				this.Skill();
			else if (this.IsOthers())
				this.Others();
		}

		private void Move()
		{
			WantActionData wadMove = new WantActionData();
			this.ActionSystem.SwitchActionByRule(wadMove);
		}

		private void Skill()
		{
			throw new NotImplementedException();
		}

		private void Others()
		{
			throw new NotImplementedException();
		}

		public void Run()
		{
			throw new NotImplementedException();
		}

	}

	public class Stage
	{
		public event EventHandler StageStarted;
		public event EventHandler StageEnded;

		private Dictionary<string, Actor> DicActor;

		void Run()
		{
			// 			this.SelectHeros();
			// 			this.Loading();
			// 			this.PlayGame();
			// 			this.ExitGame();

			foreach (var vk in this.DicActor)
			{
				vk.Value.Run();
			}
		}

		void Enter()
		{
			A.RaiseEvent(this, this.StageStarted, EventArgs.Empty);
		}

		void Leave()
		{
			A.RaiseEvent(this, this.StageEnded, EventArgs.Empty);
		}

		void Loading()
		{
		}

// 		void CreateUnit()
// 		{
// 			this.CreateScene();
// 			this.CreateHero();
// 			this.CreateMonster();
// 		}
// 
// 		void PlayGame()
// 		{
// 			this.CreateUnit();
// 			this.Readying();
// 			this.Playing();
// 			this.GameOver();
// 		}
// 
// 		void Playing()
// 		{
// 			this.MoveHero();
// 			this.HitHero();
// 			this.KillHero();
// 
// 			this.KillMonster();
// 			this.HitMonster();
// 			this.MoveMonster();
// 		}
// 
// 		void MoveHero()
// 		{
// 			this.Input();
// 			this.Event();
// 			this.Rule();
// 			this.ActionSystem();
// 			this.ChangeData();
// 			this.NotifyRenderSystem();
// 
// 			this.NotifyNetworkSystem();
// 			this.NotifyGameServer();
// 			this.NotifyOthers();
// 
// 			this.DoActionSystemOnOthers();
// 		}
// 
// 		void HitHero()
// 		{
// 			this.Input();
// 			this.Event();
// 			this.Rule();
// 			this.ActionSystem();
// 			this.ChangeData();
// 			this.NotifyRenderSystem();
// 
// 			this.OnHitOther();
// 
// 			this.DoActionSystemOnOthers();
// 
// 		}
// 
// 		void OnHitOther()
// 		{
// 			this.CalculateProperties();
// 		}
// 
// 		void OnEnemiesDead()
// 		{
// 			if (this.rule.IsEnd)
// 			{
// 				this.OnCompleted();
// 			}
// 		}
// 
// 		void OnTimeOver()
// 		{
// 			if (this.rule.IsEnd)
// 			{
// 				this.OnCompleted();
// 			}
// 		}
// 
// 		void OnNetworkDisconnected()
// 		{
// 			if (this.rule.IsEnd)
// 			{
// 				this.OnCompleted();
// 			}
// 		}
	}
}
