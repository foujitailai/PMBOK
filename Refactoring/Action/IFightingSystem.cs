using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
	using System.Text.RegularExpressions;

	public interface IFightingSystem
	{
	}

	class PluginInfo
	{
		public string PType;
	}
	class ActionInfo
	{
		public PluginInfo[] Plugins { get; set; }
	}

	public class WantActionData
	{
		public long ActionID = 0;
	}

	/// <summary>
	/// 提供动作系统的功能
	/// </summary>
	public interface IActionSystem
	{
		IAction Action { get; }

		event EventHandler ActionChanged;
		event EventHandler AttackCollided;

		void SwitchActionImmediately(WantActionData want);
		void SwitchActionByRule(WantActionData want);
		long CheckNextAction();
	}

	/// <summary>
	/// 组织IActionSystem的功能，使它可以根据特定方式去运转
	/// </summary>
	public interface IRun
	{
		/// <summary>
		/// FSM或查表????????来换替换，在外部进行配置？
		/// </summary>
		void Run();
	}

	public interface IAction
	{
		long ActionID { get; }

		List<IShaftPlugin> Plugins { get; }

		void Reset();

		void Switch(WantActionData wad);

		void Add(IShaftPlugin plugin);

		void Del(IShaftPlugin plugin);
	}

	public interface IShaftBase
	{
		bool IsEnable { get; }

		bool IsValidRange(float currentTime);
	}

	public interface IShaftPlugin : IRun, IShaftBase
	{
		void OnEnable();

		void OnDisable();

		void OnActionEnd();
	}

	// Assistant

	/// <summary>
	/// 先放在这里吧,其它的东西,其实简单的版本可以直接使用EventHandle就完成了
	///  e += next.e
	/// </summary>
	public interface IChain
	{
		void Request(EventArgs e);
		IChain Next { get; set; }
	}

	public interface ITreeNode
	{
		ITreeNode Parent { get; set; }

		ITreeNode NextSibling { get; }

		ITreeNode PrevSibling { get; }

		List<ITreeNode> Children { get; set; }

		ITreeNode GetChildAt(int index);

		int GetIndex(ITreeNode aChild);
	}


}
