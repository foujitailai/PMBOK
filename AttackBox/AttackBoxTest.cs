using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	using System.Runtime.Remoting.Messaging;

	using Fighting;

	using UnityEngine;

	[TestClass]
	public class AttackBoxTest
	{
		public class FakeLikeGameObject : ILikeGameObject
		{
			public GameObject GO { get { return null; } }
			public ILikeGameObject parent { get
			{
				return this._parent;
			}
			}

			private readonly ILikeGameObject _parent;
			public FakeLikeGameObject(ILikeGameObject parent)
			{
				this._parent = parent;
			}

			public bool Equals(ILikeGameObject other)
			{
				return this.GO == other.GO;
			}
		}

		class TestingAttackBoxImpl : AttackBoxImpl
		{

			class FakeActionInfo : IActionInfo
			{
				public ShaftBase GetShaftByGO(GameObject myGo)
				{
					return null;
				}
			}

			class FakeActionManager : IActionManager
			{
				public Actor Actor { get; set; }

				public bool Invincible { get; set; }
			}

			class FakeActionState : IActionState
			{
				public void OnAttacked(Collider attackBox, Collider other, ShaftAttack rAttack)
				{
					
				}
			}

			private FakeActionInfo actionInfo = new FakeActionInfo();

			private FakeActionManager actionManager = new FakeActionManager();

			private FakeActionState actionState = new FakeActionState();

			public TestingAttackBoxImpl(ILikeGameObject self)
				: base(self)
			{
			}

			protected override ShaftAttack NewGetShaftAttack(IActionInfo actionInfo)
			{
				return null;
			}

			protected override Collider NewGetComponentCollider()
			{
				return null;
			}

			protected override IActionInfo NewGetComponentActionInfo(ILikeGameObject parent)
			{
				return this.actionInfo;
			}

			protected override IActionManager NewGetComponentActionManager(ILikeGameObject rObjTarget)
			{
				return this.actionManager;
			}

			protected override IActionState NewGetComponentActionStage(ILikeGameObject parent)
			{
				return this.actionState;
			}
		}

		[TestMethod]
		public void TestCreate()
		{
			var f = new TestingAttackBoxImpl(new FakeLikeGameObject(null));
		}

		[TestMethod]
		public void TestFirst()
		{
			var f = new TestingAttackBoxImpl(
				new FakeLikeGameObject(
					new FakeLikeGameObject(
						new FakeLikeGameObject(null))));


			Assert.AreEqual(null, f.NewGetAM());

			f.NewCheck();

			Assert.AreNotEqual(null, f.NewGetAM());
		}
	}
}
