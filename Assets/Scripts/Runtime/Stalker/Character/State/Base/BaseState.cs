namespace StudyProject.Character
{
	public abstract class BaseState
	{
		public abstract void OnStateEnter();
		public abstract void Act();
		public abstract void OnStateExit();
	}
}