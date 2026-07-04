using System;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class NpcController : MonoBehaviour, IDestroyable
	{
		[SerializeField]
		private AlertController _alertController;

		private NpcState _npcState;

		public event Action<IDestroyable> DestroyEvent;

		private void FixedUpdate()
		{
			if (_npcState != null)
			{
				_npcState.Act();
			}
		}

		public void Initialize()
		{
			_alertController.Initialize(this);
		}

		public void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}
	}
}