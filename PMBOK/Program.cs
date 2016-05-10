using System;

namespace PMBOK
{

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			ProjectManagement pm = new TestProjectManagement();
			pm.Processing();
		}
	}
}
