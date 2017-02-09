namespace ClassLibrary1
{
	using System;
	using System.Collections.Generic;

	public class TreeNode : ITreeNode
	{
		public ITreeNode Parent { get; set; }

		public ITreeNode NextSibling
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ITreeNode PrevSibling
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public List<ITreeNode> Children { get; set; }

		public ITreeNode GetChildAt(int index)
		{
			throw new NotImplementedException();
		}

		public int GetIndex(ITreeNode aChild)
		{
			throw new NotImplementedException();
		}
	}

	public class DefaultMutableTreeNode : TreeNode
	{
		public object UserObject { get; set; }

		public DefaultMutableTreeNode()
		{
		}

		public DefaultMutableTreeNode(object userObject)
		{
			this.UserObject = userObject;
		}
	}

}