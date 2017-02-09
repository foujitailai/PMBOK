namespace ClassLibrary1
{
	using System;
	using System.Collections.Generic;

	public class ASAction : IAction, IRun
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

		public ASAction(ActionSystem actionSystem)
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
					var shaft = new ShaftAttack();
					// [LINK]连接ShaftAttackBox与AttackBoxCollided
					shaft.Collided = this.ActionSystem.AttackCollision.OnCollided;
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
}