using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ClassLibrary1;

namespace ClassLibrary1
{
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
		public EventHandler OnCollided;

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

		private void OnCollided2()
		{
			// TODO 碰撞之后,将是一个非常复杂的事情,将这个事件传递出去,自己不做什么处理

			//     [内部]  将一些shaft传递添加到碰撞双方

			//     [外部]  技能效果的应用,伤血,改变动作的请求
			//this.action.ActionSystem.AttackBoxCollided(this);

			this.OnCollided(this, EventArgs.Empty);
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
					shaft.OnCollided = this.ActionSystem.AttackBoxCollided.OnCollided;
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

		public event EventHandler OnSwitchAction;

		public event EventHandler OnAttackBoxCollided;

		private AttackBoxCollided attackBoxCollided = new AttackBoxCollided();
		public AttackBoxCollided AttackBoxCollided { get { return this.attackBoxCollided; } }

		public ActionSystem()
		{
			// [LINK]连接ActionSystem与AttackBoxCollided
			this.attackBoxCollided.OnValidCollision += (sender, e) => this.OnAttackBoxCollided(this, e);
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
			this.OnSwitchAction(this, EventArgs.Empty);
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

	public class AttackBoxCollided
	{
		public event EventHandler OnValidCollision;

		public void OnCollided(object sender, EventArgs e)
		{
			// 是有效的碰撞吗？
			if (this.IsValidCollision())
			{
				// 进行各种相关的变化
				this.ApplyConllision();

				this.OnValidCollision(this, EventArgs.Empty);
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
