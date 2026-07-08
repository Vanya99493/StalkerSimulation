using System;
using DG.Tweening;
using UnityEngine;

namespace StalkerSimulation.Weapon
{
	public class WeaponBase : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private AmmunitionSpawner _ammunitionSpawner;

		[SerializeField]
		private WeaponEffectsController _weaponEffectsController;
		
		[Space(20)]
		[SerializeField]
		private Transform _muzzle;
		
		[Space(20)]
		[SerializeField]
		private WeaponData _weaponData;
		
		private int _currentBulletAmount;
		private bool _isShootingAllowed;
		private bool _isTriggerHolding;

		private Tween _blockWeaponTween;
		
		public WeaponType WeaponType => WeaponType.AK47;
		public Transform Muzzle => _muzzle;

		private void Update()
		{
			if (_isShootingAllowed && _isTriggerHolding)
			{
				Shoot();
			}
		}

		public void Initialize()
		{
			_currentBulletAmount = _weaponData.BulletsInCartridge;
			_isTriggerHolding = false;
			_isShootingAllowed = true;
		}

		public void SetTriggerHold(bool isHolding)
		{
			_isTriggerHolding = isHolding;
		}

		public void Shoot()
		{
			if (_currentBulletAmount > 0)
			{
				ShotBullet();
			}
			else
			{
				Reload();
			}
		}

		public void Reload()
		{
			_isShootingAllowed = false;
			
			_weaponEffectsController.ActivateReloadEffects();
		}

		private void ShotBullet()
		{
			_isShootingAllowed = false;
			
			_currentBulletAmount--;
			_ammunitionSpawner.InstantiateBullet();
			_weaponEffectsController.ActivateShotEffects();
			
			BlockWeaponOnTime(
				_weaponData.DelayBetweenShots,
				() =>
				{
					_isShootingAllowed = true;
				});
		}

		private void BlockWeaponOnTime(float blockingTime, Action onCompleteCallback = null)
		{
			float passedTime = 0f;
			
			_blockWeaponTween?.Kill();
			_blockWeaponTween = DOTween.To(
					() => passedTime,
					x => passedTime = x,
					blockingTime,
					blockingTime)
				.OnComplete(() => onCompleteCallback?.Invoke());
		}
	}
}