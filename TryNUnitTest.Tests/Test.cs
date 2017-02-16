using NUnit.Framework;
using System;
namespace TryNUnitTest.Tests
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestCase()
		{
    		Assert.Throws<ArgumentException>(
			  () => { throw new ArgumentException(); });
		}

		[Test]
		public void TestCase2()
		{
			Assert.AreEqual(1, 2);
		}
	}
}
