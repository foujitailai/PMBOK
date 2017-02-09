namespace ClassLibrary1
{
	using System;

	public class ShaftBase : IShaftBase
	{
		private bool isEnable;
		public bool IsEnable
		{
			get
			{
				return this.isEnable;
			}
		}

		public void SetEnable(bool enable)
		{
			this.isEnable = enable;
		}

		public bool IsValidRange(float currentTime)
		{
			throw new NotImplementedException();
		}
	}
}