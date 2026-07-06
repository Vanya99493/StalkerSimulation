namespace StalkerSimulation.Npc
{
	public abstract class NpcState : INpcState
	{
		protected INpcController _npcController;

		public abstract float AlertRadius { get; }
		
		public void Initialize(INpcController npcController)
		{
			_npcController = npcController;
		}
		
		public abstract void EnterState();
		public abstract void Act();
		public abstract void ExitState();
	}
}