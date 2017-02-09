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
			// [LINK]����ActionSystem��AttackCollision
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
			// �ж�����[����]
			//  ���롢����  ת����Ϊ����
			var requests = this.GetRequests();

			// �����߼�
			this.SpecialProcess();

			// �ܷ��е�[����]
			WantActionData wad;
			if (this.CanSwitch(requests, out wad))
			{
				// �еĴ���[�ڲ�]
				// �еĴ���[�ⲿ]
				this.SwitchAction(wad);
			}
		}

		private void SwitchAction(WantActionData wad)
		{
			// �еĴ���[�ڲ�]
			IAction action = this.Action;
			action.Switch(wad);

			// �еĴ���[�ⲿ]
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
			// �ƶ�ʱ������а������������customTime��Ϊ�˴��������Զ��ƶ��ı䷽������ʱ����
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