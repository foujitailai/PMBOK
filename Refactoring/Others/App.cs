namespace Refactoring
{
	using System;
	using System.Collections.Generic;
	using System.Threading;

	public class App
	{
		Input input = new Input();
		List<Thread> threads = new List<Thread>();
		private ITreeNode node;

		private void Enter()
		{
			this.node = new DefaultMutableTreeNode(this);
			A.Tree.Register(this, this.node);

			//new Action().BeginInvoke(this.PlayStage);
			this.threads.Add(new Thread(() => this.PlayStage()));
		}

		private void Leave()
		{
			this.threads.ForEach((obj) => obj.Abort());
			this.threads.Clear();

			A.Tree.Unregister(this);
		}

		private void Tick()
		{
			this.input.OnInput(EventArgs.Empty);
		}

		public void Run()
		{
			this.Enter();

			this.Tick();

			this.Leave();
		}

		public void PlayStage()
		{
			bool isStageEnd = false;
			Stage stage = new Stage();
			stage.StageEnded += (sender, e) => isStageEnd = true;

			while (!isStageEnd)
			{
				stage.Run();
			}
		}
	}
}