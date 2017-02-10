namespace Refactoring
{
	using System;

	public class Actor : IRun
	{
		public string Name;

		public IActionSystem ActionSystem;

		private DefaultMutableTreeNode node;

		private bool isInputDirty;

		public Actor()
		{
			this.node = new DefaultMutableTreeNode(this);
			A.Tree.Register(this, this.node);
			this.node.Parent = A.Tree.Cast(this.GetInput());
		}

		private object GetInput()
		{
			throw new NotImplementedException();
		}

		public void OnInput()
		{
			// 			if (this.IsMove())
			// 				this.Move();
			// 			else if (this.IsSkill())
			// 				this.Skill();
			// 			else if (this.IsOthers())
			// 				this.Others();
			this.isInputDirty = true;
		}

		private void FillKeys()
		{
			throw new NotImplementedException();
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
			//this.UStageMgr.Run();
			//this.BuffMgr.Run();

			if (this.isInputDirty)
			{
				this.FillKeys();
			}

			((IRun)this.ActionSystem).Run();

			this.UpdateMove();
		}

		private void UpdateMove()
		{
			throw new NotImplementedException();
		}
	}
}