using System.Collections.Generic;
using System.Linq;

public abstract class StateMachine : IStationStateSwitcher
{
    protected List<IState> _states;
    protected IState _currentState;

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(s => s is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput()
    {
        _currentState.HandleInput();
    }

    public void Update()
    {
        _currentState.Update();
    }
}
