using System;
using System.Collections.Generic;
using StalkerSimulation.Environment;
using Unity.AI.Navigation;
using UnityEngine;

namespace StalkerSimulation.Npc
{
	public class NpcController : MonoBehaviour, INpcController, IDestroyable
	{
		[SerializeField]
		private AnimationController _animationController;
		
		[SerializeField]
		private AlertController _alertController;
		
		[SerializeField]
		private NpcMovementController _movementController;
		
		[SerializeField]
		private HealthController _npcHealthController;
		
		private NpcData _npcData;
		private ICheckPoint _currentCheckPoint;
		private OrderData _orderData;

		private Dictionary<Type, NpcState> _states = new();
		private NpcState _currentNpcState;
		
		public IAnimationController AnimationController => _animationController;
		public INpcMovementController MovementController => _movementController;
		public ICheckPoint CurrentCheckPoint => _currentCheckPoint;
		public OrderData OrderData => _orderData.Clone();
		
		public string Name => _npcData.Name;
		public TeamType TeamType => _npcData.TeamType;

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
			
			// --- Debug ---
			_currentStateDebugString = _currentNpcState?.ToString();
		}

		public void Initialize(
			NpcData npcData,
			NavMeshSurface navMeshSurface)
		{
			_npcData = npcData;
			
			_alertController.Initialize(this);
			_movementController.Initialize(navMeshSurface);
			_npcHealthController.Initialize(npcData.MaxHealthPoints, npcData.CurrentHealthPoints);
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

		public bool ChangeState<T>() where T : NpcState
		{
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
					ChangeState<MoveToCheckPointState>();
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
		
		// -------------
		// --- Debug ---
		// -------------
		
		[Space(20)]
		[Header("Debug")]
		[SerializeField]
		private string _currentStateDebugString;
		
		[SerializeField]
		private CheckPoint _checkPointToMove;
		
		[ContextMenu("Hold")]
		public void Hold()
		{
			SetOrder(new OrderData(OrderType.Hold));
		}

		[ContextMenu("Observe")]
		public void Observe()
		{
			SetOrder(new OrderData(OrderType.Observe));
		}

		[ContextMenu("Patrol Inside")]
		public void PatrolInside()
		{
			SetOrder(new OrderData(OrderType.PatrolInnerYard));
		}

		[ContextMenu("Patrol Outside")]
		public void PatrolOutside()
		{
			SetOrder(new OrderData(OrderType.PatrolOuterArea));
		}

		[ContextMenu("Move To CheckPoint")]
		public void MoveToCheckPoint()
		{
			SetOrder(new MoveToCheckPointOrderData(OrderType.MoveToCheckPoint, _checkPointToMove));
		}
	}
}