namespace CodeBase.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}