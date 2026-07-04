namespace StalkerSimulation.Npc
{
	public abstract class NpcState
	{
		public abstract void OnStateEnter();
		public abstract void Act();
		public abstract void OnStateExit();
	}
}