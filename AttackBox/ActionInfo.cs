using System.Collections;
using System.Collections.Generic;

using Fighting;

using UnityEngine;

namespace Fighting
{
	public interface IBindGameObjectToShaft
	{
		void InstantiateShaftAll();

		void DestoryGameObjectOnShafts();
		
		void ResetShaftsInfo();

		void ShaftsUpdateState();
	}

	public class BindGameObjectToShaft : IBindGameObjectToShaft
	{
		public Dict<ShaftBase, ILikeGameObject> ShaftsInfo { get; private set; }

		protected virtual List<ShaftBase> CustomShafts { get { return this.actionInfoImpl.CustomShafts; } }

		protected virtual Shafts Shafts { get { return this.actionInfoImpl.Shafts; } }

		private ActionInfoImpl actionInfoImpl;

		public BindGameObjectToShaft(ActionInfoImpl actionInfoImpl)
		{
			this.ShaftsInfo = new Dict<ShaftBase, ILikeGameObject>();
			this.actionInfoImpl = actionInfoImpl;
		}

		public ILikeGameObject GetGameObject(ShaftBase shaft)
		{
			ILikeGameObject shaftObject = null;
			if (this.ShaftsInfo.TryGetValue(shaft, out shaftObject))
			{
				return shaftObject;
			}

			return null;
		}

		public ShaftBase GetShaft(ILikeGameObject myGo)
		{
			foreach (var v in this.ShaftsInfo)
			{
				// 注意不要使用==号，这里判断的是结构体里面的那个对象
				// 有没有办法为接口弄==号出来呢？
				//if (v.Value.Equals(myGo))
				if (v.Value == myGo)
				{
					return v.Key;
				}
			}

			return null;
		}

		public void InstantiateShaft(ShaftBase[] shafts)
		{
			if (null == shafts)
			{
				return;
			}

			int count = shafts.Length;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = shafts[index];

				if (!this.ShaftsInfo.ContainsKey(myShaft))
				{
					var myObject = this.InstantiateGameObject(myShaft);
					if (null != myObject)
					{
						this.ShaftsInfo.Add(myShaft, myObject);
					}
				}
			}
		}

		protected virtual ILikeGameObject InstantiateGameObject(ShaftBase myShaft)
		{
			var actionManager = this.actionInfoImpl.GetActionManager();
			var obj = myShaft.Instantiate(actionManager.CurrentAction);
			return obj ? new LikeGameObjectImpl(obj) : null;
		}

		public void InstantiateShaftAll()
		{
			this.InstantiateShaft(this.Shafts.GetShafts());
			this.InstantiateShaft(this.CustomShafts.ToArray());
		}

		public void ResetShaftsInfo()
		{
			if (this.ShaftsInfo != null)
			{
				this.ShaftsInfo.Clear();
			}
		}

		public void DestoryGameObjectOnShafts()
		{
			if (this.ShaftsInfo != null && this.ShaftsInfo.Count > 0)
			{
				foreach (var pair in this.ShaftsInfo)
				{
					pair.Key.DestroyAction(pair.Value.GO);
				}
			}
		}

		public void ShaftsUpdateState()
		{
			if (null != this.ShaftsInfo && null != this.Shafts)
			{
				Loop.L(
					this.Shafts.GetShafts(),
					rShaft =>
					{
						if (this.ShaftsInfo.ContainsKey(rShaft))
						{
							rShaft.UpdateState(this.ShaftsInfo[rShaft].GO, false);
						}
					});
			}
		}

	}

	public class ActionInfoImpl
	{
		protected ILikeGameObject Self;

		public ActionInfoImpl(ILikeGameObject self)
		{
			this.Self = self;
			this.AttackCustom = new Dict<ShaftAttack, bool>();
			this.SkillData = null;
			this.customShafts = new List<ShaftBase>();
			this.bindGameObjectToShaft = new BindGameObjectToShaft(this);
		}

		public IBindGameObjectToShaft BindGameObjectToShaft { get { return this.bindGameObjectToShaft;} }

		#region Fields

		private List<ShaftBase> customShafts;
		public List<ShaftBase> CustomShafts { get { return this.customShafts; } }

		#endregion

		#region Constructors and Destructors

		#endregion

		#region Delegates

		public delegate void LoopShaftsCallback(ShaftBase obj, float actionTime, float animTime);

		#endregion

		#region MOVEING
		#endregion

		#region Public Properties

		public long ActionID { get; set; }

		public GameObject AttackActor { get; set; } // 谁他丫的打的我

		public ShaftAttack AttackActorShaft { get; set; }

		public Dict<ShaftAttack, bool> AttackCustom { get; set; }

		public bool IsAttacked { get; set; }

		public Shafts Shafts { get; set; }

		private BindGameObjectToShaft bindGameObjectToShaft;

		// 俺是不是打中了人！打中了true
		public SkillData SkillData { get; set; } // 当前动作的技能数据

		// 那丫用什么配置到到我的
		public Actor ThrowEnemy { get; set; }

		#endregion

		#region Public Methods and Operators

		public static ShaftBase[] FindShafts(ShaftType type, ShaftBase[] shafts)
		{
			if (shafts == null)
			{
				return new ShaftBase[0];
			}

			var resultShafts = new List<ShaftBase>();
			int count = shafts.Length;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase shaft = shafts[index];

				if (type == ShaftType.None || shaft.Type == type)
				{
					resultShafts.Add(shaft);
				}
			}

			return resultShafts.ToArray();
		}

		// 投技过程中，双方的对手
		public void AddCustomShafts(ShaftBase[] shafts, ShaftAttack attack, bool bInstantiateShaft, bool bAutoRemove = false)
		{
			if (null != attack)
			{
				// 添加过了！
				if (this.AttackCustom.ContainsKey(attack))
				{
					return;
				}

				this.AttackCustom.Add(attack, true);
			}

			if (bInstantiateShaft)
			{
				this.InstantiateShaft(shafts);
			}
			if (bAutoRemove)
			{
				for (int nIndex = 0; nIndex < shafts.Length; ++nIndex)
				{
					shafts[nIndex].AutoRemove = true;
					shafts[nIndex].AutoRemoveStartTime = Time.time;
				}
			}

			if (this.CustomShafts == null || this.CustomShafts.Count == 0)
			{
				this.customShafts = new List<ShaftBase>(shafts);
			}
			else
			{
				this.CustomShafts.AddRange(shafts);
			}
		}

		public void AddCustomShafts(ShaftBase[] shafts, bool bInstantiateShaft, bool bAutoRemove = false)
		{
			this.AddCustomShafts(shafts, null, bInstantiateShaft, bAutoRemove);
		}

		public ShaftBase FindShaft(float time, ShaftType type)
		{
			ShaftBase result = this.FindShaft(time, this.Shafts.GetShaftByType(type));
			if (result != null)
			{
				return result;
			}

			return this.FindCustomShaft(time, type);
		}

		/// <summary>
		///     从第一个开始查找寻找出符合类型的一个Shaft
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public ShaftBase FindShaft(ShaftType type)
		{
			ShaftBase result = this.FindShaft(this.Shafts.GetShaftByType(type));
			if (result != null)
			{
				return result;
			}

			return this.FindCustomShaft(type);
		}

		/// <summary>
		///     从最后一个向第一个超找一个 type类型time之间的shaft
		/// </summary>
		/// <param name="time"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ShaftBase FindShaftR(float time, ShaftType type)
		{
			ShaftBase result = this.FindCustomShaftR(time, type);
			if (result != null)
			{
				return result;
			}

			return this.FindShaftR(time, this.Shafts.GetShaftByType(type));
		}

		public ShaftBase[] FindShafts(ShaftType type)
		{
			var result = new List<ShaftBase>();

			FindShafts(result, this.Shafts.GetShaftByType(type));
			this.FindCustomShafts(result, type);

			return result.ToArray();
		}

		public ActionManager GetActionManager()
		{
			return this.Self.parent.GO.GetComponent<ActionManager>();
		}

		public ShaftBase GetShaft(ILikeGameObject myGo)
		{
			return this.bindGameObjectToShaft.GetShaft(myGo);
		}

		public void InstantiateShaft(ShaftBase[] shafts)
		{
			this.bindGameObjectToShaft.InstantiateShaft(shafts); 
			
		}

		public bool IsEnableShaft(float animTime, ShaftBase shaft, bool onlyInTime)
		{
			if (onlyInTime)
			{
				return shaft.InTime(animTime);
			}

			if ((shaft.Lean == LeanType.None || (this.IsAttacked && shaft.Lean == LeanType.AttackSucceed))
				&& shaft.InTime(animTime))
			{
				return true;
			}

			return false;
		}

		public void LoopShafts(ShaftType type, float actionTime, float animTime, LoopShaftsCallback rAction)
		{
			if (null == rAction) return;

			var rTypeShafts = this.Shafts.GetShaftByType(type);
			if (null != rTypeShafts)
			{
				for (int nIndex = 0; nIndex < rTypeShafts.Length; ++nIndex)
				{
					var shaft = rTypeShafts[nIndex];
					if (shaft.Lean == LeanType.None
						|| (this.IsAttacked && shaft.Lean == LeanType.AttackSucceed && shaft.Target == TargetType.Self)) rAction(shaft, actionTime, animTime);
				}
			}
			if (null != this.CustomShafts)
			{
				for (int nIndex = 0; nIndex < this.CustomShafts.Count; ++nIndex)
				{
					var shaft = this.CustomShafts[nIndex];
					if (shaft.Type == type) rAction(shaft, actionTime, animTime);
				}
			}
		}

		#endregion

		#region Methods

		protected ShaftBase FindCustomShaft(float time, ShaftType type)
		{
			if (null == this.CustomShafts)
			{
				return null;
			}

			int count = this.CustomShafts.Count;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = this.CustomShafts[index];

				if ((type == ShaftType.None || myShaft.Type == type) && myShaft.InTime(time))
				{
					return myShaft;
				}
			}

			return null;
		}

		protected ShaftBase FindCustomShaft(ShaftType type)
		{
			if (null == this.CustomShafts)
			{
				return null;
			}

			int count = this.CustomShafts.Count;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = this.CustomShafts[index];

				if (ShaftType.None == type || myShaft.Type == type)
				{
					return myShaft;
				}
			}

			return null;
		}

		protected ShaftBase FindCustomShaftR(float time, ShaftType type)
		{
			if (null == this.CustomShafts)
			{
				return null;
			}

			int count = this.CustomShafts.Count;
			for (int index = count - 1; index >= 0; --index)
			{
				ShaftBase myShaft = this.CustomShafts[index];

				if ((type == ShaftType.None || myShaft.Type == type) && myShaft.InTime(time))
				{
					return myShaft;
				}
			}

			return null;
		}

		protected void FindCustomShafts(List<ShaftBase> result, ShaftType type)
		{
			if (null == this.CustomShafts)
			{
				return;
			}

			int count = this.CustomShafts.Count;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = this.CustomShafts[index];

				if (myShaft.Type == type)
				{
					result.Add(myShaft);
				}
			}
		}

		protected ShaftBase FindShaft(float time, ShaftBase[] shafts)
		{
			if (null == shafts)
			{
				return null;
			}

			int count = shafts.Length;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = shafts[index];

				if ((myShaft.Lean == LeanType.None || (this.IsAttacked && myShaft.Lean == LeanType.AttackSucceed))
					&& myShaft.InTime(time))
				{
					return myShaft;
				}
			}

			return null;
		}

		protected ShaftBase FindShaft(ShaftBase[] shafts)
		{
			if (null == shafts)
			{
				return null;
			}

			int count = shafts.Length;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = shafts[index];

				if (myShaft.Lean == LeanType.None || (this.IsAttacked && myShaft.Lean == LeanType.AttackSucceed))
				{
					return myShaft;
				}
			}

			return null;
		}

		protected ShaftBase FindShaftR(float time, ShaftBase[] shafts)
		{
			if (null == shafts)
			{
				return null;
			}

			int count = shafts.Length;
			for (int index = count - 1; index >= 0; --index)
			{
				ShaftBase myShaft = shafts[index];

				if ((myShaft.Lean == LeanType.None || (this.IsAttacked && myShaft.Lean == LeanType.AttackSucceed))
					&& myShaft.InTime(time))
				{
					return myShaft;
				}
			}

			return null;
		}

		protected void FindShafts(List<ShaftBase> result, ShaftBase[] shafts)
		{
			if (null == shafts)
			{
				return;
			}

			int count = shafts.Length;
			for (int index = 0; index < count; ++index)
			{
				ShaftBase myShaft = shafts[index];

				if (myShaft.Lean == LeanType.None || (this.IsAttacked && myShaft.Lean == LeanType.AttackSucceed))
				{
					result.Add(myShaft);
				}
			}
		}

		#endregion

		public void ResetCustomShafts()
		{
			this.customShafts = new List<ShaftBase>();
		}

		public ILikeGameObject GetGameObject(ShaftBase shaft)
		{
			return this.bindGameObjectToShaft.GetGameObject(shaft);
		}

	}
}

// 挂在动作上面
public class ActionInfo : MonoBehaviour, IActionInfo
{

	private ActionInfoImpl impl;
	private void Awake()
	{
		this.impl = new ActionInfoImpl(new LikeGameObjectImpl(this.gameObject));
	}

	private void OnDestroy()
	{
		this.impl.BindGameObjectToShaft.DestoryGameObjectOnShafts();
	}

	public IBindGameObjectToShaft BindGameObjectToShaft { get { return this.impl.BindGameObjectToShaft; } }


	public long ActionID { get { return this.impl.ActionID; } set { this.impl.ActionID = value; } }

	/// <summary>
	/// 谁他丫的打的我
	/// </summary>
	public GameObject AttackActor { get { return this.impl.AttackActor; } set { this.impl.AttackActor = value; } }

	public ShaftAttack AttackActorShaft { get { return this.impl.AttackActorShaft; } set { this.impl.AttackActorShaft = value; } }

	public Dict<ShaftAttack, bool> AttackCustom { get { return this.impl.AttackCustom; } set { this.impl.AttackCustom = value; } }

	/// <summary>
	/// 俺是不是打中了人！打中了true
	/// </summary>
	public bool IsAttacked { get { return this.impl.IsAttacked; } set { this.impl.IsAttacked = value; } }

	public Shafts Shafts { get { return this.impl.Shafts; }}
	public void SetShafts(Shafts shafts) { this.impl.Shafts = shafts; }

	public List<ShaftBase> CustomShafts { get { return this.impl.CustomShafts; } }

	/// <summary>
	/// 当前动作的技能数据
	/// </summary>
	public SkillData SkillData { get { return this.impl.SkillData; } set { this.impl.SkillData = value; } }

	/// <summary>
	/// 那丫用什么配置到到我的
	/// </summary>
	public Actor ThrowEnemy { get { return this.impl.ThrowEnemy; } set { this.impl.ThrowEnemy = value; } }

	public static ShaftBase[] FindShafts(ShaftType type, ShaftBase[] shafts)
	{
		return ActionInfoImpl.FindShafts(type, shafts);
	}

	/// <summary>
	/// 投技过程中，双方的对手
	/// </summary>
	/// <param name="shafts"></param>
	/// <param name="attack"></param>
	/// <param name="bInstantiateShaft"></param>
	/// <param name="bAutoRemove"></param>
	public void AddCustomShafts(ShaftBase[] shafts, ShaftAttack attack, bool bInstantiateShaft, bool bAutoRemove = false)
	{
		this.impl.AddCustomShafts(shafts, attack, bInstantiateShaft, bAutoRemove);
	}

	public void AddCustomShafts(ShaftBase[] shafts, bool bInstantiateShaft, bool bAutoRemove = false)
	{
		this.impl.AddCustomShafts(shafts, bInstantiateShaft, bAutoRemove);
	}

	public ShaftBase FindShaft(float time, ShaftType type)
	{
		return this.impl.FindShaft(time, type);
	}

	public ShaftBase FindShaft(ShaftType type)
	{
		return this.impl.FindShaft(type);
	}

	public ShaftBase FindShaftR(float time, ShaftType type)
	{
		return this.impl.FindShaftR(time, type);
	}

	public ShaftBase[] FindShafts(ShaftType type)
	{
		return this.impl.FindShafts(type);
	}

	public ShaftBase GetShaft(GameObject myGo)
	{
		return this.impl.GetShaft(new LikeGameObjectImpl(myGo));
	}

	public void InstantiateShaft(ShaftBase[] shafts)
	{
		this.impl.InstantiateShaft(shafts);
	}

	public bool IsEnableShaft(float animTime, ShaftBase shaft, bool onlyInTime)
	{
		return this.impl.IsEnableShaft(animTime, shaft, onlyInTime);
	}

	public void LoopShafts(ShaftType type, float actionTime, float animTime, ActionInfoImpl.LoopShaftsCallback rAction)
	{
		this.impl.LoopShafts(type, actionTime, animTime, rAction);
	}

	public void ResetCustomShafts()
	{
		this.impl.ResetCustomShafts();
	}

	public bool TryGetGameObject(ShaftBase shaft, out GameObject shaftObject)
	{
		ILikeGameObject likeGameObject = this.impl.GetGameObject(shaft);

		if (null != likeGameObject)
		{
			shaftObject = likeGameObject.GO;
			return true;
		}

		shaftObject = null;
		return false;
	}
}