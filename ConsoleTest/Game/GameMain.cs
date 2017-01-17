using System;

namespace ConsoleTest
{
	public class GameMain
	{
		public GameMain ()
		{
		}

		void Run()
		{
			new Thread (
				()=>new GameServer ().Run()
			);

			new GameClient ().Run();
		}

	}
}

