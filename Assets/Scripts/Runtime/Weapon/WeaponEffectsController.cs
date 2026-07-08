using UnityEngine;
using UnityEngine.Events;

namespace StalkerSimulation.Weapon
{
	public class WeaponEffectsController : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _shotUnityEvent;
		
		[SerializeField]
		private UnityEvent _reloadUnityEvent;

		public void ActivateShotEffects()
		{
			_shotUnityEvent?.Invoke();
		}

		public void ActivateReloadEffects()
		{
			_reloadUnityEvent?.Invoke();
		}
	}
}