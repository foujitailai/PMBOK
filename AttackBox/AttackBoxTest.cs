using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	using UnityEngine;

	[TestClass]
	public class AttackBoxTest
	{
		public class FakeLikeGameObject : ILikeGameObject
		{
			public GameObject GO { get { return null; } }
			public ILikeGameObject parent { get
			{
				return null;
			}
			}
			public bool Equals(ILikeGameObject other)
			{
				return this.GO == other.GO;
			}
		}

		class TestingAttackBoxImpl : AttackBoxImpl
		{
			public TestingAttackBoxImpl(ILikeGameObject self)
				: base(self)
			{
			}

			protected override Collider NewGetComponentCollider()
			{
				return null;
			}

			protected override ILikeGameObject NewGetParent()
			{
				return null;
			}
			protected override ActionInfo NewGetComponentActionInfo(ILikeGameObject parent)
			{
				return null;
			}

			protected override ActionManager NewGetComponentActionManager(ILikeGameObject rObjTarget)
			{
				return null;
			}

			protected override ActionState NewGetComponentActionStage(ILikeGameObject parent)
			{
				return null;
			}
		}

		[TestMethod]
		public void TestCreate()
		{
			var f = new TestingAttackBoxImpl(new FakeLikeGameObject());
		}

		[TestMethod]
		public void TestFirst()
		{
			var f = new TestingAttackBoxImpl(new FakeLikeGameObject());


			//Assert.AreEqual(null, f.NewGetAM());

			f.NewCheck();

			//Assert.AreNotEqual(null, f.NewGetAM());
		}
	}
}
