using System;

namespace ConsoleTest
{
	public class GameQuestions
	{
		public GameQuestions ()
		{
		}


		/// <summary>
		/// when game has made
		/// 从需求出发，明确要做什么，才能够很好的去做什么。
		/// </summary>
		class UseCase
		{
			
			class Player
			{
				void NormalPlay()
				{
					this.Event ();
					// 日常活动
					// 每日任务
					// 自动建立目标
				}

				void FirstPlay()
				{
					this.FastLoading ();
					this.AnonymousLogin ();
					this.FirstFight ();
					this.CreateActor ();
					this.EnterLobby ();
					this.NoviceGuide ();
					this.RedPoint ();
					this.RunChapterOne ();
				}

				void FestivalPlay()
				{
					// 商业活动
					// 数值加倍
					// 新游戏模式
				}

			}

			class Bussnessman
			{
				void GMTool()
				{
					// money
					// online number
					// e-mail
					// review role data
					// monthly statement of accounts
				}


			}

			class Development
			{
				void ServerService()
				{
					// 架设新服务器
					// 合服
					// 活动更新
					// 各种异常问题检查
					// 玩家数据异常
					// 外挂
				}
			}
		}
	}
}

