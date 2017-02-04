using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	using System.Collections.Generic;
	using ClassLibrary1;

	[TestClass]
	public class FightingSystemTest
	{
		class ShaftPluginDummy : ShaftBase, IShaftPlugin
		{
			public bool IsEnable
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public void ActionEnd()
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
				throw new NotImplementedException();
			}
		}

		[TestMethod]
		public void UseCaseMain()
		{
// 			var a = new Actor();
// 			var b = new Actor();
// 			a.hit(b);

			IActionSystem asa = new ActionSystem();
			IRun ar = (IRun) asa;

			// 测能否切动作，立即切动作
			asa.SwitchActionImmediately(new WantActionData());
			Assert.IsFalse(asa.Action.ActionID);

			// 测能否合理切动作，在各种情况下根据规则切动作
			asa.SwitchActionByRule(new WantActionData());

			//	IFightingSystem td = null;//new FightingSystem();


			IRun asra = new ActionSystem();
			asra.Run();
		}

		[TestMethod]
		public void TestShaftPlugin()
		{
			// 测能否合理调用IShaftPlugin
			IAction sa = new ImplAction();
			IShaftPlugin spa = new ShaftPluginDummy();
			sa.Add(spa);
			sa.Run();
			//sa.Step();
		}
	}
}
