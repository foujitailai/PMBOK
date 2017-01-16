using System;

namespace ConsoleTest
{
	/// <summary>
	/// 各种游戏玩法、模式
	/// </summary>
	namespace GameMode
	{
		class PveMode{}

		class PvpMode
		{
			void Enter()
			{
				this.SelectHeros ();
				this.Matching ();

				this.Loading ();
				this.PlayGame ();
				this.ExitGame ();
			}
		}	
	}

}
