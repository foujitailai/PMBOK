using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	using System.Collections.Generic;

	using Fighting;

	using UnityEngine;

	[TestClass]
	public class ActionInfoTest
	{
		[TestClass]
		public class BindGameObjectToShaftTest
		{
			private class TestingBindGameObjectToShaft : BindGameObjectToShaft
			{
				public List<ShaftBase> customShafts;
				protected override List<ShaftBase> CustomShafts { get { return this.customShafts; } }

				public Shafts shafts;
				protected override Shafts Shafts { get { return this.shafts; } }

				public TestingBindGameObjectToShaft(ActionInfoImpl actionInfoImpl)
					: base(actionInfoImpl)
				{
				}

				protected override ILikeGameObject InstantiateGameObject(ShaftBase myShaft)
				{
					if (myShaft.Type == ShaftType.Attack)
						return new AttackBoxTest.FakeLikeGameObject(null);
					return null;
				}
			}

			private class TestingShaftAttack : ShaftAttack
			{
				public int DestroyActionCount;
				public int UpdateStateCount;
				public override void DestroyAction(GameObject rGameObject)
				{
					this.DestroyActionCount++;
				}

				public override void UpdateState(GameObject rGameObject, bool enable)
				{
					this.UpdateStateCount++;
				}
			}

			private TestingBindGameObjectToShaft bind;

			[TestInitialize]
			public void SetUp()
			{
				this.bind = new TestingBindGameObjectToShaft(null);

				this.bind.customShafts = new List<ShaftBase>();
				this.bind.shafts = new Shafts();

				// 添加数据
				this.bind.shafts.Attack = new[] { new TestingShaftAttack(), new TestingShaftAttack(), new TestingShaftAttack() };
				this.bind.shafts.SyncShaftsList();
				this.bind.shafts.SortShafts();

			}

			[TestCleanup]
			public void TearDown()
			{
				this.bind = null;
			}

			[TestMethod]
			public void TestNormal()
			{
				Assert.AreEqual(0, this.bind.ShaftsInfo.Count);
				this.bind.InstantiateShaftAll();
				Assert.AreEqual(3, this.bind.ShaftsInfo.Count);
			}

			[TestMethod]
			public void TestDontIncludeGameObject()
			{
				var bind2 = new TestingBindGameObjectToShaft(null);

				bind2.customShafts = new List<ShaftBase>();
				bind2.shafts = new Shafts();

				// 添加数据
				bind2.shafts.Attack = new[] { new ShaftAttack(), new ShaftAttack() };
				bind2.shafts.Flying = new[] { new Shaft_Flying() };
				bind2.shafts.MoveSpeed = new[] { new Shaft_MoveSpeed(), new Shaft_MoveSpeed() };
				bind2.shafts.SyncShaftsList();
				bind2.shafts.SortShafts();

				Assert.AreEqual(0, bind2.ShaftsInfo.Count);
				bind2.InstantiateShaftAll();
				Assert.AreEqual(2, bind2.ShaftsInfo.Count);
			}
			
			[TestMethod]
			public void TestGetShaft()
			{
				Assert.AreEqual(0, this.bind.ShaftsInfo.Count);
				this.bind.InstantiateShaftAll();
				Assert.AreEqual(3, this.bind.ShaftsInfo.Count);

				foreach (var kv in this.bind.ShaftsInfo)
				{
					Assert.AreNotEqual(null, kv.Value);
					var shaft = this.bind.GetShaft(kv.Value);
					Assert.AreNotEqual(null, shaft);
					Assert.AreEqual(shaft, kv.Key);
				}
			}

			[TestMethod]
			public void TestUpdateState()
			{
				Assert.AreEqual(0, this.bind.ShaftsInfo.Count);
				this.bind.InstantiateShaftAll();
				Assert.AreEqual(3, this.bind.ShaftsInfo.Count);

				var updateStateCount = 0;
				this.bind.ShaftsInfo.Keys.ForEach(i => updateStateCount += (i as TestingShaftAttack).UpdateStateCount);
				Assert.AreEqual(0, updateStateCount);

				this.bind.ShaftsUpdateState();
				this.bind.ShaftsInfo.Keys.ForEach(i => updateStateCount += (i as TestingShaftAttack).UpdateStateCount);
				Assert.AreEqual(3, updateStateCount);
			}

			[TestMethod]
			public void TestDestoryGameObjectOnShafts()
			{
				Assert.AreEqual(0, this.bind.ShaftsInfo.Count);
				this.bind.InstantiateShaftAll();
				Assert.AreEqual(3, this.bind.ShaftsInfo.Count);

				var destroyActionCount = 0;
				this.bind.ShaftsInfo.Keys.ForEach(i => destroyActionCount += (i as TestingShaftAttack).DestroyActionCount);
				Assert.AreEqual(0, destroyActionCount);

				this.bind.DestoryGameObjectOnShafts();
				this.bind.ShaftsInfo.Keys.ForEach(i => destroyActionCount += (i as TestingShaftAttack).DestroyActionCount);
				Assert.AreEqual(3, destroyActionCount);
			}

		}

		[TestMethod]
		public void TestGameObjectEqual()
		{
			var l = new AttackBoxTest.FakeLikeGameObject(null);
			var r = new AttackBoxTest.FakeLikeGameObject(null);
			
			Assert.IsTrue(l.Equals(r));
			Assert.IsTrue(l == r);
		}

		[TestMethod]
		public void TestFindShaft()
		{
			ActionInfoImpl t = new ActionInfoImpl(null);
			var shaft = t.FindShaft(0.1f, ShaftType.Move);

			Assert.AreEqual(ShaftType.Move, shaft.Type);
		}

		[TestClass]
		public class FindingShaftTest
		{


			[TestMethod]
			public void TestFindShaft()
			{
				// 1.使用查找的参数返回预期的结果

				// 构造数据

				// 查找指定数据

			}

			[TestMethod]
			public void TestFindShaftException()
			{
				// 2.异常的参数返回正确结果
			}
		}
	}
}
