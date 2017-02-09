namespace Refactoring
{
	using System;

	public class A
	{
		static public void RaiseEvent(object sender, EventHandler handler, EventArgs e)
		{
			if (handler != null)
				handler(sender, e);
		}

		static public class Message
		{
			public static void Broadcast(ITreeNode node, EventArgs e)
			{
				throw new NotImplementedException();
			}

			public static void Send(ITreeNode node, EventArgs e)
			{
				throw new NotImplementedException();
			}

			public static void SendUpwards(ITreeNode node, EventArgs e)
			{
				throw new NotImplementedException();
			}
		}

		static public class Tree
		{
			public static bool Register(object obj, ITreeNode node)
			{
				// 查找字典，确定这个object是带有treenode的
				throw new NotImplementedException();
			}
			public static bool Unregister(object obj)
			{
				// 查找字典，确定这个object是带有treenode的
				throw new NotImplementedException();
			}
			public static ITreeNode Cast(object obj)
			{
				// 查找字典，确定这个object是带有treenode的
				throw new NotImplementedException();
			}
		}
	}
}