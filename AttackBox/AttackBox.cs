using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Fighting;

namespace Fighting
{

	public interface IActor
	{
		bool IsEnemy(IActor newActor);
		string TypeName { get; }
	}

	public interface IActionInfo
	{
		ShaftBase GetShaftByGO(GameObject myGo);
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
}

public interface ILikeGameObject : IEquatable<ILikeGameObject>
{
	GameObject GO { get; }

	Collider collider { get; }

	ILikeGameObject parent { get; }

	string tag { get; }
}

public class LikeGameObjectImpl : ILikeGameObject
{
	public GameObject GO { get { return this.go; } }
	public Collider collider { get { return this.go.GetComponent<Collider>(); } }
	public ILikeGameObject parent { get { return new LikeGameObjectImpl(this.go.transform.parent.gameObject); } }
	public string tag { get { return this.go.tag; } }

	private GameObject go;
	public LikeGameObjectImpl(GameObject go)
	{
		this.go = go;
	}

	public bool Equals(ILikeGameObject other)
	{
		return this.GO == other.GO;
	}
}

public class AttackBoxImpl
{
	private IActionManager _AM = null;

	private ShaftAttack _attack = null;

	private int _hitCount = 0;

	private Dict<ILikeGameObject, bool> attackedActor = new Dict<ILikeGameObject, bool>();

	protected ILikeGameObject self;

	public int HitCount { get { return this._hitCount; } }

	public int AttackedActorCount { get { return this.attackedActor.Count; } }

	public AttackBoxImpl(ILikeGameObject self)
	{
		this.self = self;
	}

	public IActionManager NewGetAM()
	{
		return this._AM;
	}

	public ShaftAttack NewGetAttack()
	{
		return this._attack;
	}

	public void NewClear()
	{
		this.attackedActor.Clear();
		this._hitCount = 0;
	}

	public void NewSimulateTriggerEnter(ILikeGameObject other)
	{
		if (other != null)
		//if (other)
		{
			this.NewOnTriggerEnter(other);
		}
	}

	private bool NewIsTarget(ILikeGameObject rObjTarget)
	{
		IActionManager rTargetAM = this.NewGetComponentActionManager(rObjTarget);
		if (rTargetAM == null || rTargetAM.NewActor == null)
		{
			return false;
		}

		// 无敌？
		if (rTargetAM.Invincible)
		{
			return false;
		}

		// 自己的Avatar  GameObject
		bool isSelf = (rTargetAM == this._AM);

		bool isActor = false;
		switch (rTargetAM.NewActor.TypeName)
		{
			case "Npc":
			case "Player":
			case "AllowDestroyObj":
				isActor = true;
				break;
			case "Bullet":
				isActor = false;
				break;
			default:
				return false;
		}

		bool isEnemy = this._AM.NewActor.IsEnemy(rTargetAM.NewActor);
		var tt = this._attack.TargetType;

		// 当目标是什么的时候，检查对应的标记条件是否满足；如果有多个目标时，会一个个检查过来
		return IsTargetByAttackTargetType(tt, isEnemy, isSelf, isActor);
	}

	public static bool IsTargetByAttackTargetType(AttackTargetType tt, bool isEnemy, bool isSelf, bool isActor)
	{
		return ((((tt & AttackTargetType.EnemyActor) != 0) && (isEnemy == true && isSelf == false && isActor == true))
			 || (((tt & AttackTargetType.EnemyBullet) != 0) && (isEnemy == true && isSelf == false && isActor == false))
			 || (((tt & AttackTargetType.SelfActor) != 0) && (isEnemy == false && isSelf == true && isActor == true))
			 || (((tt & AttackTargetType.SelfBullet) != 0) && (isEnemy == false && isSelf == true && isActor == false))
			 || (((tt & AttackTargetType.TeammateActor) != 0) && (isEnemy == false && isSelf == false && isActor == true))
			 || (((tt & AttackTargetType.TeammateBullet) != 0) && (isEnemy == false && isSelf == false && isActor == false)));
	}

	public void NewOnEnable()
	{
		this.NewCheck();
	}

	public void NewOnDisable()
	{
		this._attack = null;
		this._AM = null;
	}

	protected void NewCheck()
	{
		if (this.NewGetParent() != null)
		{
			if (this._attack == null)
			{
				modify NewGetComponentActionInfo parame to self and encapsulate the hierarchy of game object
				IActionInfo rActionInfo = this.NewGetComponentActionInfo(this.NewGetParent());
				
				if (rActionInfo != null)
				{
					this._attack = this.NewGetShaftAttack(rActionInfo);
				}
			}

			if (this._AM == null)
			{
				if (this.NewGetParent().parent != null)
				{
					this._AM = this.NewGetComponentActionManager(this.NewGetParent().parent);
				}
			}
		}
	}

	public void NewOnTriggerEnter(ILikeGameObject other)
	{
		this.NewCheck();

		// GDebug.Log("AttackBox.OnTriggerEnter:" + collider.ToString() + "<=>" + other.transform.GetPath() + " + " + other.ToString());
		// 打到的是角色
		if (other.tag == "Player") // 攻击配置项
		{
			this.HitPlayer(other);
		}

#if BULLET_THROUGH_WALL
		// 穿墙
		else if (other.tag == "Wall")
		{
			this.HitWall();
		}
#endif
	}

	private void HitPlayer(ILikeGameObject other)
	{
		if (this._attack != null && this._AM != null // 可以命中的次数
		    && (this._attack.MaxHitCount == -1 || this._attack.MaxHitCount > this._hitCount) // 没有击中过
		    && !this.attackedActor.ContainsKey(other) // 是否为有效打击目标
		    && this.NewIsTarget(other))
		{
			IActionState actionState = this.NewGetComponentActionStage(this.NewGetParent().parent);
			if (actionState != null)
			{
				this._hitCount++;
				this.attackedActor.Add(other, true);
				actionState.OnAttacked(this.NewGetComponentCollider(), other.collider, this._attack);
			}
		}
	}

	private void HitWall()
	{
		if (this._AM != null)
		{
			var bullet = this._AM.NewActor as Bullet;
			if (bullet != null)
			{
				// 子弹?
				GameStageManager.Instance.OnBulletDeath(bullet);
			}
		}
	}

	protected virtual ShaftAttack NewGetShaftAttack(IActionInfo rActionInfo)
	{
		return rActionInfo.GetShaftByGO(this.NewGetComponentCollider().gameObject) as ShaftAttack;
	}

	protected virtual Collider NewGetComponentCollider()
	{
		return this.self.GO.GetComponent<Collider>();
	}

	protected virtual ILikeGameObject NewGetParent()
	{
		return this.self.parent;
	}

	protected virtual IActionInfo NewGetComponentActionInfo(ILikeGameObject parent)
	{
		return parent.GO.GetComponent<ActionInfo>();
	}

	protected virtual IActionManager NewGetComponentActionManager(ILikeGameObject rObjTarget)
	{
		return rObjTarget.GO.GetComponent<ActionManager>();
	}

	protected virtual IActionState NewGetComponentActionStage(ILikeGameObject parent)
	{
		return parent.GO.GetComponent<ActionState>();
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
			return this.impl.NewGetAM() as ActionManager;
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
		this.impl.NewClear();
	}

	public void SimulateTriggerEnter(Collider other)
	{
		this.impl.NewSimulateTriggerEnter(new LikeGameObjectImpl(other.gameObject));
	}

	#endregion

	#region Methods

	private void Awake()
	{
		this.impl = new AttackBoxImpl(new LikeGameObjectImpl(this.gameObject));
	}

	private void OnEnable()
	{
		this.impl.NewOnEnable();
	}

	private void OnDisable()
	{
		this.impl.NewOnDisable();
	}

	private void OnTriggerEnter(Collider other)
	{
		this.impl.NewOnTriggerEnter(new LikeGameObjectImpl(other.gameObject));
	}

	#endregion

}