using System;

namespace PMBOK
{
	using System.Diagnostics;

	class Debugger
	{
		public static void Assert(bool condition)
		{
			//Debug.Assert(condition);
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//new JustTest().TestAssertParameters(1, "sss");

			ProjectManagement pm = new TestProjectManagement();
			pm.Processing();
		}
	}
}
