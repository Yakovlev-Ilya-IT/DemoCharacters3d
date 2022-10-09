using System.Collections.Generic;

public class CharacterMovementStateMachine : StateMachine
{
    private CharacterMovementStatesReusableData _reusableData;

    public CharacterMovementStateMachine(Character character)
    {
        _reusableData = new CharacterMovementStatesReusableData();

        _states = new List<IState>()
        {
            new CharacterIdlingState(this, character, _reusableData),
            new CharacterWalkingState(this, character, _reusableData),
            new CharacterRunningState(this, character, _reusableData),
            new CharacterLightStoppingState(this, character, _reusableData),
            new CharacterNormalStoppingState(this, character, _reusableData),
        };
        _currentState = _states[0];
    }
}
