using UnityEngine;

namespace StalkerSimulation.Weapon
{
	public interface IWeapon
	{
		public Transform Muzzle { get; }

		public void SetTriggerHold(bool isHolding);
		public void Shoot();
	}
}