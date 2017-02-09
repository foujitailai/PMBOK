namespace ClassLibrary1
{
	using System;
	using System.Collections.Generic;

	public class Stage
	{
		public event EventHandler StageStarted;
		public event EventHandler StageEnded;

		private Dictionary<string, Actor> DicActor;

		void Run()
		{
			// 			this.SelectHeros();
			// 			this.Loading();
			// 			this.PlayGame();
			// 			this.ExitGame();

			foreach (var vk in this.DicActor)
			{
				vk.Value.Run();
			}
		}

		void Enter()
		{
			A.RaiseEvent(this, this.StageStarted, EventArgs.Empty);
		}

		void Leave()
		{
			A.RaiseEvent(this, this.StageEnded, EventArgs.Empty);
		}

		void Loading()
		{
		}

		// 		void CreateUnit()
		// 		{
		// 			this.CreateScene();
		// 			this.CreateHero();
		// 			this.CreateMonster();
		// 		}
		// 
		// 		void PlayGame()
		// 		{
		// 			this.CreateUnit();
		// 			this.Readying();
		// 			this.Playing();
		// 			this.GameOver();
		// 		}
		// 
		// 		void Playing()
		// 		{
		// 			this.MoveHero();
		// 			this.HitHero();
		// 			this.KillHero();
		// 
		// 			this.KillMonster();
		// 			this.HitMonster();
		// 			this.MoveMonster();
		// 		}
		// 
		// 		void MoveHero()
		// 		{
		// 			this.Input();
		// 			this.Event();
		// 			this.Rule();
		// 			this.ActionSystem();
		// 			this.ChangeData();
		// 			this.NotifyRenderSystem();
		// 
		// 			this.NotifyNetworkSystem();
		// 			this.NotifyGameServer();
		// 			this.NotifyOthers();
		// 
		// 			this.DoActionSystemOnOthers();
		// 		}
		// 
		// 		void HitHero()
		// 		{
		// 			this.Input();
		// 			this.Event();
		// 			this.Rule();
		// 			this.ActionSystem();
		// 			this.ChangeData();
		// 			this.NotifyRenderSystem();
		// 
		// 			this.OnHitOther();
		// 
		// 			this.DoActionSystemOnOthers();
		// 
		// 		}
		// 
		// 		void OnHitOther()
		// 		{
		// 			this.CalculateProperties();
		// 		}
		// 
		// 		void OnEnemiesDead()
		// 		{
		// 			if (this.rule.IsEnd)
		// 			{
		// 				this.OnCompleted();
		// 			}
		// 		}
		// 
		// 		void OnTimeOver()
		// 		{
		// 			if (this.rule.IsEnd)
		// 			{
		// 				this.OnCompleted();
		// 			}
		// 		}
		// 
		// 		void OnNetworkDisconnected()
		// 		{
		// 			if (this.rule.IsEnd)
		// 			{
		// 				this.OnCompleted();
		// 			}
		// 		}
	}
}