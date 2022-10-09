using UnityEngine.InputSystem;

public class CharacterIdlingState : CharacterGroundedState
{
    public CharacterIdlingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _character.View.StartIdling();
    }

    public override void Update()
    {
        if (CheckInputIsZero())
            return;

        _stateSwitcher.SwitchState<CharacterWalkingState>();
    }

    public override void Exit()
    {
        base.Exit();

        _character.View.StopIdling();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext obj) { }
}
