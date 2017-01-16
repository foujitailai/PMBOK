using System;

namespace ConsoleTest
{
	public class GameConceptProcess
	{
		public GameConceptProcess ()
		{
			// todo to create all classes that are new kind of game object in the project

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
			this.SelectServer();

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

			this.Backpage ();

			this.Skills ();

			this.Heros ();

			this.Shopping ();

			this.Activity ();

			this.Ranking ();

			this.Relationship ();

			this.Setting ();

			this.Email ();

			this.Recharge ();
		}

		void EnterPveMode()
		{
			this.SelectStage ();
			this.EnterStage ();
		}

		void EnterStage ()
		{
			this.SelectHeros ();
			this.Loading ();
			this.PlayGame ();
			this.ExitGame ();
		}

		void PlayGame()
		{
			this.Init ();
			this.Readying ();
			this.Playing ();
			this.GameOver ();
		}

		void Playing()
		{
			this.MoveHero ();
			this.HitHero ();
			this.KillHero ();
			this.KillMonster ();
			this.HitMonster ();
			this.MoveMonster ();
			this.OnTimeOver ();
			this.OnNetworkDisconnected ();
			this.OnCompleted ();
		}

		void MoveHero()
		{
			this.Input ();
			this.Event ();
			this.Rule ();
			this.ActionSystem ();
			this.ChangeData ();
			this.NotifyRenderSystem ();

			this.NotifyNetworkSystem ();
			this.NotifyGameServer ();
			this.DoActionSystemOnServer ();
			this.NotifyOthers ();

			this.DoActionSystemOnOthers ();
		}

		void HitHero ()
		{
			this.Input ();
			this.Event ();
			this.Rule ();
			this.ActionSystem ();
			this.ChangeData ();
			this.NotifyRenderSystem ();

			this.OnHitOther ();

			this.DoActionSystemOnOthers ();

		}

		void OnHitOther ()
		{
			this.CalculateProperties ();
		}

		void EnterPvpMode()
		{
			this.SelectHeros ();
			this.Matching ();
			this.Loading ();
			this.PlayGame ();
			this.ExitGame ();
		}

		void Exit()
		{
			// 清理程序，关闭游戏引擎，安全关闭
		}
	}
}

