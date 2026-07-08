using System;
using StalkerSimulation.Weapon;

namespace StalkerSimulation
{
	[Serializable]
	public struct WeaponData
	{
		public int BulletsInCartridge;
		public AmmunitionType AmmunitionType;
		public float DelayBetweenShots;
		public float ReloadingTime;
	}
}