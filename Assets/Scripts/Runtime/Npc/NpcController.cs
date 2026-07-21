using System;
using System.Collections.Generic;
using StalkerSimulation.Environment;
using StalkerSimulation.Weapon;
using Unity.AI.Navigation;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class NpcController : MonoBehaviour, INpcController, IDestroyable
	{
		[SerializeField]
		private AnimationController _animationController;
		
		[SerializeField]
		private VisualizationController _visualizationController;
		
		[SerializeField]
		private AlertController _alertController;
		
		[SerializeField]
		private NpcMovementController _movementController;
		
		[SerializeField]
		private HealthController _npcHealthController;

		[Header("Weapon")]
		[SerializeField]
		private WeaponBase _weapon;

		[SerializeField]
		private Transform _weaponPivot;
		
		[Space(20)]
		[SerializeField]
		private Transform _eyeTransform;
		
		private NpcData _npcData;
		private ICheckPoint _currentCheckPoint;
		private OrderData _orderData;

		private Dictionary<Type, NpcState> _states = new();
		private NpcState _currentNpcState;

		private Quaternion _weaponDefaultRotation;
		
		public IAnimationController AnimationController => _animationController;
		public INpcMovementController MovementController => _movementController;
		public IHealthController HealthController => _npcHealthController;
		public IWeapon Weapon => _weapon;
		public NpcData NpcData => _npcData;
		public ICheckPoint CurrentCheckPoint => _currentCheckPoint;
		public OrderData OrderData => _orderData.Clone();
		public INpcState CurrentState => _currentNpcState;
		
		public GameObject GameObject => gameObject;
		public Transform Transform => transform;
		public Vector3 EyePosition => _eyeTransform.position;

		public event Action<IDestroyable> DestroyEvent;

		private void OnEnable()
		{
			_npcHealthController.TakeDamageEvent += OnTakeDamageEventHandler;
			_npcHealthController.DeathEvent += OnDeathEventHandler;
		}

		private void OnDisable()
		{
			_npcHealthController.TakeDamageEvent -= OnTakeDamageEventHandler;
			_npcHealthController.DeathEvent -= OnDeathEventHandler;
		}

		private void Update()
		{
			_currentNpcState?.Act();
		}

		public void Initialize(
			NpcData npcData,
			NavMeshSurface navMeshSurface)
		{
			_npcData = npcData;
			_weaponDefaultRotation = _weaponPivot.rotation;
			
			_visualizationController.Initialize(_npcData.Color);
			_alertController.Initialize(this);
			_movementController.Initialize(navMeshSurface);
			_npcHealthController.Initialize(npcData.MaxHealthPoints, npcData.CurrentHealthPoints);
			_weapon.Initialize();
		}

		public void InitializeBehaviour(Dictionary<Type, NpcState> states)
		{
			_states = states;
		}

		public void SetChekPoint(ICheckPoint checkPoint)
		{
			_currentCheckPoint = checkPoint;
		}

		public void SetOrder(OrderData orderData)
		{
			_orderData = orderData;
			ChangeStateAccordingToOrder();
		}

		public void Aim(Transform aimTransform)
		{
			Transform.Rotate(aimTransform.eulerAngles);
			_weaponPivot.Rotate(aimTransform != null
				? aimTransform.eulerAngles
				: _weaponDefaultRotation.eulerAngles);
		}

		public bool ChangeState<T>() where T : NpcState
		{
			if (_currentNpcState != null && _currentNpcState.GetType() == typeof(T))
			{
				return true;
			}
			
			if (_states.TryGetValue(typeof(T), out NpcState state))
			{
				_currentNpcState?.ExitState();
				_currentNpcState = state;
				_currentNpcState.EnterState();

				return true;
			}

			return false;
		}
		
		// TODO: think how to automatize this code to avoid its extending on adding new states
		public void ChangeStateAccordingToOrder()
		{
			switch (_orderData.OrderType)
			{
				case OrderType.Observe:
					ChangeState<ObserveState>();
					break;
				case OrderType.PatrolInnerYard:
				case OrderType.PatrolOuterArea:
					ChangeState<PatrolState>();
					break;
				case OrderType.MoveToCheckPoint:
				case OrderType.AttackCheckPoint:
					ChangeState<MoveToCheckPointState>();
					break;
				case OrderType.AttackTarget:
					ChangeState<AttackState>();
					break;
				default:
					ChangeState<HoldState>();
					break;
			}
		}

		public void Destroy()
		{
			DestroyEvent?.Invoke(this);
		}

		private void OnTakeDamageEventHandler(DamageArgs damageArgs)
		{
			
		}

		private void OnDeathEventHandler(DamageArgs damageArgs)
		{
			ChangeState<DeathState>();
		}
	}
}