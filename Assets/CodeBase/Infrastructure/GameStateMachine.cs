using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private IState _activeState;
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader)
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            
            IState state = _states[typeof(TState)];
            _activeState = state;
            
            state.Enter();
        }
    }
}