using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private IState _activeState;
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState.Exit();
            
            IState state = _states[typeof(TState)];
            _activeState = state;
            
            state.Enter();
        }
    }
}