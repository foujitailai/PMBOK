using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fighting
{


}

public interface ILikeGameObject : IEquatable<ILikeGameObject>
{
	GameObject GO { get; }

	ILikeGameObject parent { get; }
}

public class LikeGameObjectImpl : ILikeGameObject
{
	public GameObject GO { get { return this.go; } }
	public ILikeGameObject parent { get{return new LikeGameObjectImpl(this.go.transform.parent.gameObject);} }

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
	private ActionManager _AM = null;

	private ShaftAttack _attack = null;

	private int _hitCount = 0;

	private Dict<Collider, bool> attackedActor = new Dict<Collider, bool>();

	private ILikeGameObject self;

	public AttackBoxImpl(ILikeGameObject self)
	{
		this.self = self;
	}

	public ActionManager NewGetAM()
	{
		return this._AM;
	}

	public void NewClear()
	{
		this.attackedActor.Clear();
		this._hitCount = 0;
	}

	public void NewSimulateTriggerEnter(Collider other)
	{
		if (other)
		{
			this.NewOnTriggerEnter(other);
		}
	}

	public bool NewIsTarget(GameObject rObjTarget)
	{
		ActionManager rTargetAM = this.NewGetComponentActionManager(new LikeGameObjectImpl(rObjTarget));
		if (rTargetAM == null || rTargetAM.Actor == null)
		{
			return false;
		}

		// 无敌？
		if (rTargetAM.Invincible)
		{
			return false;
		}

		// 自己的Avatar  GameObject
		if (this.NewGetParent() == null || this.NewGetParent().parent == null)
		{
			return false;
		}
		bool isSelf = rObjTarget == this.NewGetParent().parent.GO;

		bool isActor = false;
		switch (rTargetAM.Actor.GetType().Name)
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

		bool isEnemy = this._AM.Actor.IsEnemy(rTargetAM.Actor);
		var tt = this._attack.TargetType;

		// 当目标是什么的时候，检查对应的标记条件是否满足；如果有多个目标时，会一个个检查过来
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

	public void NewCheck()
	{
		if (this.NewGetParent() != null)
		{
			if (this._attack == null)
			{
				ActionInfo rActionInfo = this.NewGetComponentActionInfo(this.NewGetParent());
				
				if (rActionInfo != null)
				{
					this._attack = rActionInfo.GetShaftByGO(this.NewGetComponentCollider().gameObject) as ShaftAttack;
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

	public void NewOnTriggerEnter(Collider other)
	{
		this.NewCheck();

		// GDebug.Log("AttackBox.OnTriggerEnter:" + collider.ToString() + "<=>" + other.transform.GetPath() + " + " + other.ToString());
		// 打到的是角色
		if (other.tag == "Player") // 攻击配置项
		{
			if (this._attack != null && this._AM != null // 可以命中的次数
				&& (this._attack.MaxHitCount == -1 || this._attack.MaxHitCount > this._hitCount) // 没有击中过
				&& !this.attackedActor.ContainsKey(other) // 是否为有效打击目标
				&& this.NewIsTarget(other.gameObject) )
			{
				ActionState actionState = this.NewGetComponentActionStage(this.NewGetParent().parent);
				if (actionState != null)
				{
					this._hitCount++;
					this.attackedActor.Add(other, true);
					actionState.OnAttacked(this.NewGetComponentCollider(), other, this._attack);
				}
			}
		}

#if BULLET_THROUGH_WALL
	// 穿墙
		else if (other.tag == "Wall")
		{
			if (this._AM != null)
			{
				var bullet = this._AM.Actor as Bullet;
				if (bullet != null)
				{
					// 子弹?
					GameStageManager.Instance.OnBulletDeath(bullet);
				}
			}
		}
#endif
	}

	protected virtual Collider NewGetComponentCollider()
	{
		return this.self.GO.GetComponent<Collider>();
	}

	protected virtual ILikeGameObject NewGetParent()
	{
		return this.self.parent;
	}

	protected virtual ActionInfo NewGetComponentActionInfo(ILikeGameObject parent)
	{
		return parent.GO.GetComponent<ActionInfo>();
	}

	protected virtual ActionManager NewGetComponentActionManager(ILikeGameObject rObjTarget)
	{
		return rObjTarget.GO.GetComponent<ActionManager>();
	}

	protected virtual ActionState NewGetComponentActionStage(ILikeGameObject parent)
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
			return this.impl.NewGetAM();
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
		this.impl.NewSimulateTriggerEnter(other);
	}

	#endregion

	#region Methods

	private void Awake()
	{
		this.impl = new AttackBoxImpl(new LikeGameObjectImpl(this.gameObject));
	}

	private bool IsTarget(GameObject rObjTarget)
	{
		return this.impl.NewIsTarget(rObjTarget);
	}

	private void OnEnable()
	{
		this.impl.NewOnEnable();
	}

	private void OnDisable()
	{
		this.impl.NewOnDisable();
	}

	private void Check()
	{
		this.impl.NewCheck();
	}

	private void OnTriggerEnter(Collider other)
	{
		this.impl.NewOnTriggerEnter(other);
	}

	#endregion

}