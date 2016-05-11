using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBOK
{
	using System.Diagnostics;
	using System.Reflection;

	class JustTest
	{
		public void TestAssertParameters(int a, string b)
		{
			// NO EASY WAY !!!

			StackTrace st = new StackTrace();
			var parameters = st.GetFrame(0).GetMethod().GetParameters();
			foreach (var pi in parameters)
			{
				Console.WriteLine(pi.ToString());
			}

			Type ss = typeof(ProjectManagementPlanning);
			var sssss = ss.GetRuntimeMethods();
			var curMethod = ss.GetMethod("DevelopProjectManagementPlan", BindingFlags.NonPublic | BindingFlags.Instance);
			var dfdfdf = curMethod.GetParameters();
		}
	}
}
