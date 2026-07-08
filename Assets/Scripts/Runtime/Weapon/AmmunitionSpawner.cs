using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Weapon
{
	public class AmmunitionSpawner : MonoBehaviour
	{
		[SerializeField]
		private AmmunitionFactory _ammunitionFactory;

		[SerializeField]
		private Transform _muzzleTransform;
		
		[SerializeField]
		private AmmunitionData _ammunitionData;
		
		private List<Ammunition> _ammunitionList = new();

		public void InstantiateBullet()
		{
			Ammunition ammunition = _ammunitionFactory.Create(_muzzleTransform.position, _muzzleTransform.rotation);
			ammunition.Initialize(_ammunitionData);
			_ammunitionList.Add(ammunition);
		}

		public void DestroyAllBullets()
		{
			foreach (Ammunition ammunition in _ammunitionList)
			{
				ammunition.Destroy();
			}
			
			_ammunitionList.Clear();
		}
	}
}