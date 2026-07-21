using System;
using UnityEngine;

namespace StalkerSimulation
{
	public interface IDestroyable
	{
		public GameObject GameObject { get; }
		
		public event Action<IDestroyable> DestroyEvent;

		public void Destroy();
	}
}