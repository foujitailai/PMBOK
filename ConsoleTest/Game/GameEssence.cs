using System;

namespace ConsoleTest
{
	/// <summary>
	/// 整个核心战斗相关的内容
	/// TODO 考虑将逻辑与显示分离开来，MVC模式在这里也可以实现的，下可描述的可以都是接口，具体实现，没有！
	/// 我需要先把乱七八糟的东西都倒出为，这样子脑子才有空间去思考，去关联，去创造
	/// </summary>
	namespace GameEssence
	{
		class Stage
		{
			void Enter ()
			{
				this.SelectHeros ();
				this.Loading ();
				this.PlayGame ();
				this.ExitGame ();
			}

			void Leave()
			{
			}

			void Loading()
			{
			}

			void CreateUnit()
			{
				this.CreateScene ();
				this.CreateHero ();
				this.CreateMonster ();
			}

			void PlayGame()
			{
				this.CreateUnit ();
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

			void OnEnemiesDead ()
			{
				if (this.rule.IsEnd) {
					this.OnCompleted ();
				}
			}

			void OnTimeOver ()
			{
				if (this.rule.IsEnd) {
					this.OnCompleted ();
				}
			}

			void OnNetworkDisconnected ()
			{
				if (this.rule.IsEnd) {
					this.OnCompleted ();
				}
			}
		}

		class Hero
		{
		}

		class Monster
		{
		}

		/// <summary>
		/// 物理、显示由这个类来负责，将HERO、MONSTER表现出来
		/// </summary>
		class Scene
		{
		}

		class Rule
		{
			class Expression
			{
			}

			class FiniteStateMachine
			{
				// table?
			}
		}

		/// <summary>
		/// 英雄在战斗中的模块形态、表现形式
		/// </summary>
		class ActionSystem
		{
			class ActionLogic
			{
			}

			class ActionShow
			{
			}
		}
	}
	
}
