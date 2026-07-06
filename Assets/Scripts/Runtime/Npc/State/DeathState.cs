namespace StalkerSimulation.Npc
{
	public class DeathState : NpcState
	{
		private readonly DeathStateData _deathStateData;

		public DeathState(DeathStateData deathStateData)
		{
			_deathStateData = deathStateData;
		}

		~DeathState()
		{
			
		}
		
		public override void EnterState()
		{
			_npcController.AnimationController.SetDeathTrigger();
		}

		public override void Act() { }
		public override void ExitState() { }
	}
}