using System;

namespace StalkerSimulation.Npc
{
	[Serializable]
	public class OrderData
	{
		public OrderType OrderType;

		public OrderData(OrderType orderType)
		{
			OrderType = orderType;
		}

		public virtual OrderData Clone() => new OrderData(OrderType);
	}
}