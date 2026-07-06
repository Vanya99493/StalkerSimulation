using UnityEngine;

namespace StalkerSimulation.UI
{
	public abstract class BasePanel : MonoBehaviour
	{
		public bool IsActive { get; private set; }
		
		public virtual void Open()
		{
			SubscribeOnEvents();
			
			IsActive = true;
			gameObject.SetActive(true);
		}

		public virtual void Close()
		{
			UnsubscribeFromEvents();
			
			gameObject.SetActive(false);
			IsActive = false;
		}

		protected virtual void SubscribeOnEvents() { }
		protected virtual void UnsubscribeFromEvents() { }
	}
}