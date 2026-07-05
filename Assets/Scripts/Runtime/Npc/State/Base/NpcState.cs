namespace StalkerSimulation.Npc
{
	public abstract class NpcState
	{
		protected INpcController _npcController;

		public void Initialize(INpcController npcController)
		{
			_npcController = npcController;
		}
		
		public abstract void EnterState();
		public abstract void Act();
		public abstract void ExitState();
	}
}