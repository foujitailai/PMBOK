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
			public override GameObject GO { get { return null; } }
			public override ILikeGameObject parent { get
			{
				return this._parent;
			}
			}

			private readonly ILikeGameObject _parent;

			public string _tag;

			private Collider _collider;

			public FakeLikeGameObject(ILikeGameObject parent)
			{
				this._parent = parent;
			}

			public override Collider collider { get
			{
				return this._collider;
			} }

			public override string tag { get
			{
				return this._tag;
			} }
		}

		public class FakeActionInfo : IActionInfo
		{
			public ShaftBase GetShaft(GameObject myGo)
			{
				return null;
			}
		}

		public class FakeActionManager : IActionManager
		{
			public IActor NewActor { get; set; }

			public bool Invincible { get; set; }
		}

		public class FakeActionState : IActionState
		{
			public bool IsOnAttackedCalled;

			public void OnAttacked(Collider attackBox, Collider other, ShaftAttack rAttack)
			{
				this.IsOnAttackedCalled = true;
			}
		}

		public class FakeAttackBoxGameObject : FakeLikeGameObject, IFightingGameObject
		{
			public FakeActionInfo actionInfo = new FakeActionInfo();

			public FakeActionManager actionManager = new FakeActionManager();

			public FakeActionState actionState = new FakeActionState();

			public FakeAttackBoxGameObject(ILikeGameObject parent)
				: base(parent)
			{
			}

			public IActionState ActionState
			{
				get
				{
					return this.actionState;
				}
			}

			public IActionInfo ActionInfo
			{
				get
				{
					return this.actionInfo;
				}
			}

			public IActionManager ActionManager
			{
				get
				{
					return this.actionManager;
				}
			}
		}

		class TestingAttackBoxImpl : AttackBoxImpl
		{
			public ShaftAttack ShaftAttack;

			public TestingAttackBoxImpl(ILikeGameObject self)
				: base(self)
			{
			}

			public void TestingCheck()
			{
				this.Check();
			}

			protected override ShaftAttack GetShaftAttack(IActionInfo actionInfo)
			{
				return this.ShaftAttack;
			}

			protected override Collider GetComponentCollider()
			{
				return null;
			}

			protected override IActionInfo GetSelfActionInfo()
			{
				return (this.Self as FakeAttackBoxGameObject).ActionInfo;
			}

			protected override IActionManager GetSelfActionManager()
			{
				return (this.Self as FakeAttackBoxGameObject).ActionManager;
			}

			protected override IActionManager GetTargetActionManager(ILikeGameObject obj)
			{
				return (obj as FakeAttackBoxGameObject).ActionManager;
			}
			
			protected override IActionState GetSelfActionState()
			{
				return (this.Self as FakeAttackBoxGameObject).ActionState;
			}
		}

		internal class TestingActor : IActor
		{
			public bool IsEnemy(IActor newActor)
			{
				return true;
			}

			public string TypeName { get; set; }
		}

		private TestingAttackBoxImpl testTar;
		FakeAttackBoxGameObject self;
		FakeAttackBoxGameObject other;

		[TestInitialize]
		public void SetUp()
		{
			this.self = new FakeAttackBoxGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			this.other = new FakeAttackBoxGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			this.testTar = new TestingAttackBoxImpl(this.self);

			this.self.actionManager.NewActor = new TestingActor();
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
			Assert.AreEqual(null, this.testTar.ActionManager);
			Assert.AreEqual(null, this.testTar.Attack);

			this.testTar.ShaftAttack = new ShaftAttack();

			this.testTar.TestingCheck();

			Assert.AreNotEqual(null, this.testTar.Attack);
			Assert.AreNotEqual(null, this.testTar.ActionManager);
		}

		[TestMethod]
		public void TestOnTriggerEnterNothing()
		{
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterThrowException()
		{
			this.other._tag = "Player";
			this.testTar.ShaftAttack = new ShaftAttack();
			this.testTar.ShaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.other.actionManager.NewActor = new TestingActor();
			((TestingActor)this.other.actionManager.NewActor).TypeName = "Nonono";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterOnce()
		{
			this.other._tag = "Player";
			this.testTar.ShaftAttack = new ShaftAttack();
			this.testTar.ShaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.other.actionManager.NewActor = new TestingActor();
			((TestingActor)this.other.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);

			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterTwice()
		{
			this.other._tag = "Player";

			this.testTar.ShaftAttack = new ShaftAttack();
			this.testTar.ShaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.other.actionManager.NewActor = new TestingActor();
			((TestingActor)this.other.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);

			var other2 = new FakeAttackBoxGameObject(new FakeLikeGameObject(new FakeLikeGameObject(null)));
			other2._tag = "Player";
			other2.actionManager.NewActor = new TestingActor();
			((TestingActor)other2.actionManager.NewActor).TypeName = "Player";

			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.OnTriggerEnter(other2);
			Assert.AreEqual(2, this.testTar.HitCount);
			Assert.AreEqual(2, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);
			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.OnTriggerEnter(other2);
			Assert.AreEqual(2, this.testTar.HitCount);
			Assert.AreEqual(2, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterClear()
		{
			this.other._tag = "Player";
			this.testTar.ShaftAttack = new ShaftAttack();
			this.testTar.ShaftAttack.TargetType = AttackTargetType.EnemyActor;
			this.other.actionManager.NewActor = new TestingActor();
			((TestingActor)this.other.actionManager.NewActor).TypeName = "Player";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);

			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.Clear();
			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);

			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);

			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

		[TestMethod]
		public void TestOnTriggerEnterBullet()
		{
			this.other._tag = "Player";
			this.testTar.ShaftAttack = new ShaftAttack();
			this.testTar.ShaftAttack.TargetType = AttackTargetType.EnemyBullet;
			this.other.actionManager.NewActor = new TestingActor();
			((TestingActor)this.other.actionManager.NewActor).TypeName = "Bullet";

			Assert.AreEqual(0, this.testTar.HitCount);
			Assert.AreEqual(0, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(true, this.self.actionState.IsOnAttackedCalled);

			this.self.actionState.IsOnAttackedCalled = false;
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
			this.testTar.OnTriggerEnter(this.other);
			Assert.AreEqual(1, this.testTar.HitCount);
			Assert.AreEqual(1, this.testTar.AttackedActorCount);
			Assert.AreEqual(false, this.self.actionState.IsOnAttackedCalled);
		}

	}
}
