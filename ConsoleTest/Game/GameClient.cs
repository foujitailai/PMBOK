using System;

namespace ConsoleTest
{
	public class GameClient
	{
		public GameClient ()
		{
		}


		void Init()
		{
			// 初始化游戏引擎
			this.Loading();
		}

		void Loading()
		{
		}

		void Exit()
		{
			// 清理程序，关闭游戏引擎，安全关闭
		}

		void Run()
		{
			// 游戏运行
			this.Init ();

			new Lobby ().Run();

			this.Exit ();
		}

	}
}

