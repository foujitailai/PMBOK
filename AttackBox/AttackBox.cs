using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Fighting;


namespace TestObject
{

	public class GameObject
	{
		public static implicit operator bool(GameObject exists)
		{
			return !object.ReferenceEquals(exists, null);
		}
	}

	public abstract class ILikeObject<T> : IEquatable<ILikeObject<T>> where T : class
	{
		public abstract T GO { get; }

		public virtual bool Equals(ILikeObject<T> other)
		{
			if (object.ReferenceEquals(other, null)) return false;
			if (object.ReferenceEquals(this, other)) return true;

			return (EqualityComparer<T>.Default.Equals(this.GO, other.GO));
			//return this.GO == other.GO;
		}

		public static implicit operator bool(ILikeObject<T> exists)
		{
			if (object.ReferenceEquals(exists, null)) return false;

			return (bool)(object)exists.GO;
		}

		public static bool operator ==(ILikeObject<T> l, ILikeObject<T> r)
		{
			if (object.ReferenceEquals(l, r)) return true;
			if (object.ReferenceEquals(l, null) || object.ReferenceEquals(r, null)) return false;

			return (EqualityComparer<T>.Default.Equals(l.GO, r.GO));
		}

		public static bool operator !=(ILikeObject<T> l, ILikeObject<T> r)
		{
			if (object.ReferenceEquals(l, r)) return false;
			if (object.ReferenceEquals(l, null) || object.ReferenceEquals(r, null)) return true;

			return (!EqualityComparer<T>.Default.Equals(l.GO, r.GO));
		}

		public override int GetHashCode()
		{
			// 确保空值时都返回0,表示都相等; 非空值时,直接使用GO的HashCode
			return object.ReferenceEquals(this.GO, null) ? 0 : this.GO.GetHashCode();
			// 匿名类型(anonymous type, 它应该是class, http://www.bubuko.com/infodetail-1027631.html)产生一个HashCode
			//return new { this.GO }.GetHashCode();
		}
	}

	public abstract class ILikeGameObject : ILikeObject<GameObject>
	{
		public abstract ILikeGameObject parent { get; }

		public abstract string tag { get; }

		public abstract bool IsValid { get; }

	}

	public class FakeLikeGameObject : ILikeGameObject
	{
		public override GameObject GO
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool IsValid
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override ILikeGameObject parent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string tag
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}

	public class LikeGameObjectImpl : ILikeGameObject
	{
		public override GameObject GO
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool IsValid
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override ILikeGameObject parent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string tag
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}

	public class FakeGameObject
	{
		public static implicit operator bool(FakeGameObject exists)
		{
			return !object.ReferenceEquals(exists, null);
		}
	}

	public class FakeLikeObject : ILikeObject<FakeGameObject>
	{
		private FakeGameObject go;
		public override FakeGameObject GO
		{
			get
			{
				return this.go;
			}
		}

		public FakeLikeObject(FakeGameObject go)
		{
			this.go = go;
		}
	}
}



public abstract class ILikeObject<T>
{
	public abstract T GO { get; }
}

public abstract class ILikeGameObject : IEquatable<ILikeGameObject>
{
	public abstract Collider collider { get; }

	public abstract ILikeGameObject parent { get; }

	public abstract string tag { get; }

	public abstract bool IsValid { get; }

	public virtual bool Equals(ILikeGameObject other)
	{
		if (object.ReferenceEquals(other, null)) return false;
		if (object.ReferenceEquals(this, other)) return true;

		return this.GO == other.GO;
	}

	public static implicit operator bool(ILikeGameObject exists)
	{
		if (object.ReferenceEquals(exists, null)) return false;

		return exists.GO;
	}

 	public static bool operator ==(ILikeGameObject l, ILikeGameObject r)
 	{
		if (object.ReferenceEquals(l, r)) return true;
		if (object.ReferenceEquals(l, null) || object.ReferenceEquals(r, null)) return false;

 		return l.GO == r.GO;
 	}

 	public static bool operator !=(ILikeGameObject l, ILikeGameObject r)
 	{
		if (object.ReferenceEquals(l, r)) return false;
		if (object.ReferenceEquals(l, null) || object.ReferenceEquals(r, null)) return true;

 		return l.GO != r.GO;
 	}

	public override int GetHashCode()
	{
		// 确保空值时都返回0,表示都相等; 非空值时,直接使用GO的HashCode
		return (this.GO == null) ? 0 : this.GO.GetHashCode();
		// 匿名类型(anonymous type, 它应该是class, http://www.bubuko.com/infodetail-1027631.html)产生一个HashCode
		//return new { this.GO }.GetHashCode();
	}
}

namespace Fighting
{

	public interface IActor
	{
		bool IsEnemy(IActor newActor);
		string TypeName { get; }
	}

	public interface IActionInfo
	{
		ShaftBase GetShaft(GameObject myGo);
	}

	public interface IActionManager
	{
		IActor NewActor { get; set; }

		bool Invincible { get; set; }
	}

	public interface IActionState
	{
		void OnAttacked(Collider attackBox, Collider other, ShaftAttack rAttack);
	}

	public interface IFightingGameObject
	{
		IActionState ActionState { get; }
		IActionInfo ActionInfo { get; }
		IActionManager ActionManager { get; }
	}

	public class AttackBoxImpl
	{
		private IActionManager actionManager;

		private ShaftAttack attack;

		private int hitCount;

		private readonly Dict<ILikeGameObject, bool> attackedActor;

		protected ILikeGameObject Self;

		public int HitCount { get { return this.hitCount; } }

		public int AttackedActorCount { get { return this.attackedActor.Count; } }

		public AttackBoxImpl(ILikeGameObject self)
		{
			this.Self = self;
			this.attackedActor = new Dict<ILikeGameObject, bool>();
		}

		public IActionManager ActionManager
		{
			get
			{
				return this.actionManager;
			}
		}

		public ShaftAttack Attack
		{
			get
			{
				return this.attack;
			}
		}

		public void OnEnable()
		{
			this.Check();
		}

		public void OnDisable()
		{
			this.attack = null;
			this.actionManager = null;
		}

		public void Clear()
		{
			this.attackedActor.Clear();
			this.hitCount = 0;
		}

		private ILikeGameObject GetPlayerGameObj()
		{
			return (this.Self.parent != null) ? this.Self.parent.parent : null;
		}

		private ILikeGameObject GetActionGameObj()
		{
			return this.Self.parent;
		}

		private bool IsTarget(ILikeGameObject targetGameObj)
		{
			IActionManager targetActionManager = this.GetTargetActionManager(targetGameObj);

			if (targetActionManager == null || targetActionManager.NewActor == null || 
			    this.GetPlayerGameObj() == null)
			{
				return false;
			}

			// 无敌？
			if (targetActionManager.Invincible)
			{
				return false;
			}

			bool isSelf = (targetActionManager == this.ActionManager);

			bool isActor;
			try{ isActor = this.IsActor(targetActionManager); } catch (Exception e){return false;}

			bool isEnemy = this.actionManager.NewActor.IsEnemy(targetActionManager.NewActor);

			// 当目标是什么的时候，检查对应的标记条件是否满足；如果有多个目标时，会一个个检查过来
			return this.IsTargetByAttackTargetType(this.attack.TargetType, isEnemy, isSelf, isActor);
		}

		private bool IsActor(IActionManager targetActionManager)
		{
			switch (targetActionManager.NewActor.TypeName)
			{
				case "Npc":
				case "Player":
				case "AllowDestroyObj":
					return true;
				case "Bullet":
					return false;
				default:
					throw new Exception();
			}
		}

		private bool IsTargetByAttackTargetType(AttackTargetType tt, bool isEnemy, bool isSelf, bool isActor)
		{
			return ((((tt & AttackTargetType.EnemyActor) != 0) && (isEnemy == true && isSelf == false && isActor == true))
			        || (((tt & AttackTargetType.EnemyBullet) != 0) && (isEnemy == true && isSelf == false && isActor == false))
			        || (((tt & AttackTargetType.SelfActor) != 0) && (isEnemy == false && isSelf == true && isActor == true))
			        || (((tt & AttackTargetType.SelfBullet) != 0) && (isEnemy == false && isSelf == true && isActor == false))
			        || (((tt & AttackTargetType.TeammateActor) != 0) && (isEnemy == false && isSelf == false && isActor == true))
			        || (((tt & AttackTargetType.TeammateBullet) != 0) && (isEnemy == false && isSelf == false && isActor == false)));
		}

		protected void Check()
		{
			if (this.GetActionGameObj() != null)
			{
				if (this.attack == null)
				{
					IActionInfo actionInfo = this.GetSelfActionInfo();
				
					if (actionInfo != null)
					{
						this.attack = this.GetShaftAttack(actionInfo);
					}
				}

				if (this.actionManager == null)
				{
					if (this.GetPlayerGameObj() != null)
					{
						this.actionManager = this.GetSelfActionManager();
					}
				}
			}
		}

		public void OnTriggerEnter(ILikeGameObject targetGameObj)
		{
			if (targetGameObj == null || !targetGameObj.IsValid)
			{
				return;
			}

			this.Check();

			// GDebug.Log("AttackBox.OnTriggerEnter:" + collider.ToString() + "<=>" + targetGameObj.transform.GetPath() + " + " + targetGameObj.ToString());
			// 打到的是角色
			if (targetGameObj.tag == "Player") // 攻击配置项
			{
				this.HitPlayer(targetGameObj);
			}

#if BULLET_THROUGH_WALL
// 穿墙
		else if (targetGameObj.tag == "Wall")
		{
			this.HitWall();
		}
#endif
		}

		private void HitPlayer(ILikeGameObject targetGameObj)
		{
			if (this.CanAttack(targetGameObj) && this.IsTarget(targetGameObj))
			{
				IActionState actionState = this.GetSelfActionState();
				if (actionState != null)
				{
					this.hitCount++;
					this.attackedActor.Add(targetGameObj, true);

					// 最重要的输出点
					actionState.OnAttacked(this.GetComponentCollider(), targetGameObj.collider, this.attack);
				}
			}
		}

		private bool CanAttack(ILikeGameObject targetGameObj)
		{
			if (this.attack != null && this.actionManager != null)
			{
				// 攻击盒子可以命中的次数
				if (this.attack.MaxHitCount == -1 || this.attack.MaxHitCount > this.hitCount)
				{
					// 没有击中过这个对象
					if (!this.attackedActor.ContainsKey(targetGameObj))
					{
						return true;
					}
				}
			}
			return false;
		}

		private void HitWall()
		{
			if (this.actionManager != null)
			{
				var bullet = this.actionManager.NewActor as Bullet;
				if (bullet != null)
				{
					// 子弹?
					GameStageManager.Instance.OnBulletDeath(bullet);
				}
			}
		}

		protected virtual ShaftAttack GetShaftAttack(IActionInfo actionInfo)
		{
			return actionInfo.GetShaft(this.GetComponentCollider().gameObject) as ShaftAttack;
		}

		protected virtual Collider GetComponentCollider()
		{
			return this.Self.GO.GetComponent<Collider>();
		}

		protected virtual IActionManager GetSelfActionManager()
		{
			return this.GetComponentActionManager(this.GetPlayerGameObj());
		}

		protected virtual IActionManager GetTargetActionManager(ILikeGameObject obj)
		{
			return this.GetComponentActionManager(obj);
		}

		protected virtual IActionInfo GetSelfActionInfo()
		{
			return this.GetComponentActionInfo(this.GetActionGameObj());
		}

		protected virtual IActionState GetSelfActionState()
		{
			return this.GetComponentActionState(this.GetPlayerGameObj());
		}

		private IActionInfo GetComponentActionInfo(ILikeGameObject obj)
		{
			return (obj as IFightingGameObject).ActionInfo;
		}

		private IActionManager GetComponentActionManager(ILikeGameObject obj)
		{
			return (obj as IFightingGameObject).ActionManager;
		}

		private IActionState GetComponentActionState(ILikeGameObject obj)
		{
			return (obj as IFightingGameObject).ActionState;
		}
	}
}

public class LikeGameObjectImpl : ILikeGameObject, IFightingGameObject
{
	public override GameObject GO
	{
		get
		{
			return this.go;
		}
	}

	public override Collider collider
	{
		get
		{
			return this.go.GetComponent<Collider>();
		}
	}

	public override ILikeGameObject parent
	{
		get
		{
			try
			{
				return new LikeGameObjectImpl(this.go.transform.parent.gameObject);
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}

	public override string tag
	{
		get
		{
			return this.go.tag;
		}
	}

	private GameObject go;

	public LikeGameObjectImpl(GameObject go)
	{
		this.go = go;
	}

	public override bool Equals(ILikeGameObject other)
	{
		return other != null && this.GO == other.GO;
	}

	public override bool IsValid
	{
		get
		{
			return this.go;
		}
	}

	public IActionState ActionState
	{
		get
		{
			return this.go.GetComponent<ActionState>();
		}
	}

	public IActionInfo ActionInfo
	{
		get
		{
			return this.go.GetComponent<ActionInfo>();
		}
	}

	public IActionManager ActionManager
	{
		get
		{
			return this.go.GetComponent<ActionManager>();
		}
	}
}

public class AttackBox : MonoBehaviour
{
	private AttackBoxImpl impl;

	#region Fields

	public ActionManager AM
	{
		get
		{
			return this.impl.ActionManager as ActionManager;
		}
	}

	/// <summary>
	/// 是否通过盒子的碰撞区域来触发命中事件，如果为false时，将通过SimulateTriggerEnter来进行触发
	/// </summary>
	[System.NonSerialized]
	public static bool UseAttackBoxCollision = true;

	#endregion

	#region Public Methods and Operators

	public void Clear()
	{
		this.impl.Clear();
	}

	public void SimulateTriggerEnter(Collider other)
	{
		this.impl.OnTriggerEnter(new LikeGameObjectImpl(other.gameObject));
	}

	#endregion

	#region Methods

	private void Awake()
	{
		this.impl = new AttackBoxImpl(new LikeGameObjectImpl(this.gameObject));
	}

	private void OnEnable()
	{
		this.impl.OnEnable();
	}

	private void OnDisable()
	{
		this.impl.OnDisable();
	}

	private void OnTriggerEnter(Collider other)
	{
		this.impl.OnTriggerEnter(new LikeGameObjectImpl(other.gameObject));
	}

	#endregion

}