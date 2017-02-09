using System;
using System.Diagnostics.Contracts;
using ClassLibrary1;

namespace ClassLibrary1
{
	using System.Collections.Specialized;

	public class FightingSystem
	{
		public FightingSystem()
		{
		}
	}

	class RequestData
	{

	}

	public class AttackCollision
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
}
