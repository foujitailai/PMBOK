namespace Refactoring
{
	using System;

	class ShaftAttack : ShaftBase, IShaftPlugin
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
			//this.action.ActionSystem.AttackCollided(this);

			this.Collided(this, EventArgs.Empty);
		}
	}
}