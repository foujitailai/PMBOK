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

			public Collider collider { get; set; }

			public string tag { get; set; }
		}

		class TestingAttackBoxImpl : AttackBoxImpl
		{
			internal class FakeActionInfo : IActionInfo
			{
				public ShaftBase GetShaftByGO(GameObject myGo)
				{
					return null;
				}
			}

			internal class FakeActionManager : IActionManager
			{
				public IActor NewActor { get; set; }

				public bool Invincible { get; set; }
			}

			internal class FakeActionState : IActionState
			{
				public bool IsOnAttackedCalled;
				public void OnAttacked(Collider attackBox, Collider other, ShaftAttack rAttack)
				{
					this.IsOnAttackedCalled = true;
				}
			}

			public FakeActionInfo actionInfo = new FakeActionInfo();

			public FakeActionManager actionManager = new FakeActionManager();

			public FakeActionState actionState = new FakeActionState();

			public ShaftAttack shaftAttack;

			public TestingAttackBoxImpl(ILikeGameObject self)
				: base(self)
			{
			}

			public void TestingCheck()
			{
				this.NewCheck();
			}

			protected override ShaftAttack NewGetShaftAttack(IActionInfo actionInfo)
			{
				return this.shaftAttack;
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

		internal class TestingActor : IActor
		{
			#region Implementation of IActor

			public bool IsEnemy(IActor newActor)
			{
				return true;
			}

			#region Implementation of IActor

			public string TypeName { get; set; }

			#endregion

			#endregion
		}

		private TestingAttackBoxImpl testTar;
		FakeLikeGameObject self;
		FakeLikeGameObject other;

		[TestInitialize]
		public void SetUp()
		{
			this.self = new FakeLikeGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			this.other = new FakeLikeGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			this.testTar = new TestingAttackBoxImpl(this.self);
		}

		[TestCleanup]
		public void TearDown()
		{
			this.testTar = null;
			this.other = null;
		}

		[TestMethod]
		public void TestCheck()
		{
			Assert.AreEqual(null, this.testTar.NewGetAM());
			Assert.AreEqual(null, this.testTar.NewGetAttack());

			this.testTar.shaftAttack = new ShaftAttack();

			this.testTar.TestingCheck();

			Assert.AreNotEqual(null, this.testTar.NewGetAttack());
			Assert.AreNotEqual(null, this.testTar.NewGetAM());
		}

		[TestMethod]
		public void TestOnTriggerEnterNothing()
		{
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterOnce()
		{
			this.other.tag = "Player";
			this.testTar.shaftAttack = new ShaftAttack();
			this.testTar.shaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.testTar.actionManager.NewActor = new TestingActor();
			((TestingActor)this.testTar.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);

			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterTwice()
		{
			this.other.tag = "Player";

			var other2 = new FakeLikeGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			other2.tag = "Player";

			this.testTar.shaftAttack = new ShaftAttack();
			this.testTar.shaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.testTar.actionManager.NewActor = new TestingActor();
			((TestingActor)this.testTar.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);

			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewOnTriggerEnter(other2);
			Assert.AreEqual(2, this.testTar.HitCount);
			Assert.AreEqual(2, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(2, this.testTar.HitCount);
			Assert.AreEqual(2, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterClear()
		{
			this.other.tag = "Player";
			this.testTar.shaftAttack = new ShaftAttack();
			this.testTar.shaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.testTar.actionManager.NewActor = new TestingActor();
			((TestingActor)this.testTar.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);

			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewClear();
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);

			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);

			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterBullet()
		{
			this.other.tag = "Player";
			this.testTar.shaftAttack = new ShaftAttack();
			this.testTar.shaftAttack.TargetType = AttackTargetType.EnemyBullet;
			this.testTar.actionManager.NewActor = new TestingActor();
			((TestingActor)this.testTar.actionManager.NewActor).TypeName = "Bullet";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.testTar.actionState.IsOnAttackedCalled);

			this.testTar.actionState.IsOnAttackedCalled = false;
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
			this.testTar.NewOnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.testTar.actionState.IsOnAttackedCalled);
		}

	}
}
