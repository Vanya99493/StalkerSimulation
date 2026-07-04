using System;

namespace StalkerSimulation
{
	public interface IDestroyable
	{
		public event Action<IDestroyable> DestroyEvent;

		public void Destroy();
	}
}