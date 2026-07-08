using System;
using UnityEngine;

namespace StalkerSimulation.Weapon
{
	public class Ammunition : MonoBehaviour, IDestroyable
	{
		private AmmunitionData _ammunitionData;
		
		public event Action<IDestroyable> DestroyEvent;

		public void Initialize(AmmunitionData data)
		{
			_ammunitionData = data;
		}
		
		public void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}