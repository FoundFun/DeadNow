using CodeBase.Infrastructure.Infrastructure;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.States;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}