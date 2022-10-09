using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterWalkingState : CharacterMovingState
{
    public CharacterWalkingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _reusableData.Speed = GroundedConfig.WalkingSpeed;

        _character.View.StartWalking();
    }

    public override void Update()
    {
        base.Update();

        if (CheckSpeedSwitchingTreshold())
            _stateSwitcher.SwitchState<CharacterRunningState>();
    }

    private bool CheckSpeedSwitchingTreshold() => _reusableData.InputDirection.magnitude >= _speedSwitchingTreshold;

    public override void Exit()
    {
        base.Exit();

        _character.View.StopWalking();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        base.OnMovementCanceled(context);

        _stateSwitcher.SwitchState<CharacterLightStoppingState>();
    }
}
