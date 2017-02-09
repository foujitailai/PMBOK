namespace ClassLibrary1
{
	using System;

	public class Input
	{
		public void OnInput(EventArgs e)
		{
			// 可以使用Chain of Responsibility来链接它们
			A.Message.Broadcast(A.Tree.Cast(this), EventArgs.Empty);

			// 反上传递 还是 向下传递   界面鼠标点击，第一个接到消息的是最上面的与鼠标最近的那个窗口
			
			//if (this.IsDebugInput(e))
			//{
				
			//}
			//else if (this.IsUIInput(e))
			//{
				
			//}
			//else if (this.IsActorInput(e))
			//{
			//	this.GetCurActor().OnInput(e);
			//}
			//else if (this.IsAppInput(e))
			//{

			//}
			//else if (this.IsOtherInput(e))
			//{

			//}
		}

		Actor GetCurActor()
		{
			throw new NotImplementedException();
		}
	}
}