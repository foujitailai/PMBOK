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
			this.SelectingServer();

			// login
			this.Login();

			if (this.isFirstPlay) {
				// create account
				// introducing game(first fight)
			}

			this.EnterLobby();
		}

		void EnterLobby()
		{
			this.EnterPveMode();

			this.EnterPvpMode();
		}

		void EnterPveMode()
		{
		}

		void EnterPvpMode()
		{
		}


		void Exit()
		{
			// 清理程序，关闭游戏引擎，安全关闭
		}
	}
}

