using StalkerSimulation.Environment;

namespace StalkerSimulation.Npc
{
	public class MoveToCheckPointOrderData : OrderData
	{
		public ICheckPoint DestinationCheckPoint;

		public MoveToCheckPointOrderData(OrderType orderType, ICheckPoint destinationCheckPoint) : base(orderType)
		{
			DestinationCheckPoint = destinationCheckPoint;
		}

		public override OrderData Clone() => new MoveToCheckPointOrderData(OrderType, DestinationCheckPoint);
	}
}