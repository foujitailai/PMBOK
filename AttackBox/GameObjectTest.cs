using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	using Game.Tests.TestObject;

	namespace TestObject
	{
		using System.Collections.Generic;

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
			private GameObject go;
			public override GameObject GO
			{
				get
				{
					return this.go;
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

			public FakeLikeGameObject(GameObject go)
			{
				this.go = go;
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

	[TestClass]
	public class GameObjectTest
	{
		[TestMethod]
		public void TestNull()
		{
			FakeGameObject lgo = new FakeGameObject();
			FakeGameObject rgo = new FakeGameObject();
			FakeLikeObject l = new FakeLikeObject(null);

			FakeLikeObject r = new FakeLikeObject(null);
			Assert.IsTrue(l.Equals(r));
			Assert.IsTrue(l == r);
			// Assert.AreEqual的等于判断 不行！！！ Assert.AreEqual(l, r);
			Assert.IsTrue(l.GetHashCode() == r.GetHashCode());


			r = new FakeLikeObject(rgo);
			Assert.IsFalse(l.Equals(r));
			Assert.IsFalse(l == r);
			Assert.IsFalse(l.GetHashCode() == r.GetHashCode());
		}

		[TestMethod]
		public void TestEqualsObject()
		{
			FakeGameObject lgo = new FakeGameObject();
			FakeGameObject rgo = new FakeGameObject();
			FakeLikeObject l = new FakeLikeObject(lgo);

			FakeLikeObject r = new FakeLikeObject(lgo);
			Assert.IsTrue(l.Equals(r));
			Assert.IsTrue(l == r);
			Assert.IsTrue(l.GetHashCode() == r.GetHashCode());

			ILikeObject<FakeGameObject> lo = l;
			ILikeObject<FakeGameObject> ro = r;
			Assert.IsTrue(lo.Equals(ro));
			Assert.IsTrue(lo == ro);
			Assert.IsTrue(lo.GetHashCode() == ro.GetHashCode());

			r = new FakeLikeObject(rgo);
			Assert.IsFalse(l.Equals(r));
			Assert.IsFalse(l == r);
			Assert.IsFalse(l.GetHashCode() == r.GetHashCode());

			lo = l;
			ro = r;
			Assert.IsFalse(lo.Equals(ro));
			Assert.IsFalse(lo == ro);
			Assert.IsFalse(lo.GetHashCode() == ro.GetHashCode());
		}

		[TestMethod]
		public void TestEqualsGameObject()
		{
			GameObject lgo = new GameObject();
			GameObject rgo = new GameObject();
			ILikeGameObject l = new FakeLikeGameObject(lgo);

			ILikeGameObject r = new FakeLikeGameObject(lgo);
			Assert.IsTrue(l.Equals(r));
			Assert.IsTrue(l == r);
			Assert.IsTrue(l.GetHashCode() == r.GetHashCode());

			r = new FakeLikeGameObject(rgo);
			Assert.IsFalse(l.Equals(r));
			Assert.IsFalse(l == r);
			Assert.IsFalse(l.GetHashCode() == r.GetHashCode());
		}
	}
}
