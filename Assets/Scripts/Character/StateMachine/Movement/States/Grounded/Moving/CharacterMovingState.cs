using UnityEngine;
using UnityEngine.InputSystem;

public abstract class CharacterMovingState : CharacterGroundedState
{
    protected float _speedSwitchingTreshold;
    protected float _movementStartTime;

    public CharacterMovingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
        _speedSwitchingTreshold = GroundedConfig.InputThresholdForSwitchingSpeed;
    }

    public override void Enter()
    {
        base.Enter();

        Initialize();

        _character.View.StartMoving();
    }

    private void Initialize()
    {
        _reusableData.RotationBeforeStartMovement = GetCurrentRotationAngle();

        _movementStartTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();

        _character.View.StopMoving();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (CheckInputHoldTime())
        {
            _reusableData.PossibilityAutomaticRotationDuringStop = true;
        }
        else
        {
            _reusableData.PossibilityAutomaticRotationDuringStop = false;
        }
    }

    private bool CheckInputHoldTime() => Time.time - _movementStartTime < RotationConfig.InputTimeForPossibilityAutomaticRotation;
}
