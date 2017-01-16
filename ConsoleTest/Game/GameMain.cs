using System;

namespace ConsoleTest
{
	public class GameMain
	{
		public GameMain ()
		{
			// 初始化游戏引擎
			this.Init();
			// 游戏运行
			this.Run();
			// 清理程序，关闭游戏引擎，安全关闭
			this.Exit();
		}


		void Init()
		{
			// 初始化游戏引擎
			// loading
			this.Loading();
		}
		void Loading()
		{
		}

		void Run()
		{
			new Lobby ().Run();
		}

	}
}

