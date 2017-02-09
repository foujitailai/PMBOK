namespace Refactoring
{
	using System;
	using System.Collections.Generic;

	public class ActionSystem : IRun, IActionSystem
	{
		public IAction Action { get; private set; }

		public event EventHandler ActionChanged;

		public event EventHandler AttackCollided;

		private AttackCollision attackCollision = new AttackCollision();
		public AttackCollision AttackCollision { get { return this.attackCollision; } }

		public ActionSystem()
		{
			// [LINK]连接ActionSystem与AttackCollision
			this.attackCollision.Collided += (sender, e) => this.AttackCollided(this, e);
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

			// 特殊逻辑
			this.SpecialProcess();

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

		private void SpecialProcess()
		{
			// 移动时，如果有按键，将会清除customTime，为了触摸屏的自动移动改变方向重置时间用
			//if (this.ActionInfo && this.actorInfo && this.actorInfo.BaseAction != null && this.ActionInfo.ActionID == this.actorInfo.BaseAction.Run)
			//{
			//	if (this.actorController.isMoving)
			//	{
			//		this.MyActionState.customTime = 0.0f;
			//	}
			//}
		}

	}
}