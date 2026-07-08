namespace StalkerSimulation.Npc
{
	public class AttackOrderData : OrderData
	{
		public INpcController TargetToAttack;
		
		public AttackOrderData(OrderType orderType, INpcController targetToAttack) : base(orderType)
		{
			TargetToAttack = targetToAttack;
		}

		public override OrderData Clone() => new AttackOrderData(OrderType, TargetToAttack);
	}
}