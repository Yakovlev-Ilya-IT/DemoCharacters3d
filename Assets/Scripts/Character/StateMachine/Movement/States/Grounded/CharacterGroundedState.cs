using UnityEngine.InputSystem;

public abstract class CharacterGroundedState : CharacterMovementState
{
    public CharacterGroundedState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _character.View.StartGrounded();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        PlayerInputActions.Movement.canceled += OnMovementCanceled;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        PlayerInputActions.Movement.canceled -= OnMovementCanceled;
    }

    public override void Exit()
    {
        base.Exit();

        _character.View.StopGrounded();
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _stateSwitcher.SwitchState<CharacterIdlingState>();
    }
}
