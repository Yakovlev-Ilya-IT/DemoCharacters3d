using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterRunningState : CharacterMovingState
{
    private bool _isSpeedSwitchingThresholdPassed;
    private float _timeAfterSwitchingThresholdPassed;
    private float _timeToDetectNextState = 0.1f;

    public CharacterRunningState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Initialize();

        _character.View.StartRunning();
    }

    private void Initialize()
    {
        _reusableData.Speed = GroundedConfig.RunningSpeed;

        _timeAfterSwitchingThresholdPassed = 0;
        _isSpeedSwitchingThresholdPassed = false;
    }

    public override void Update()
    {
        base.Update();

        if (CheckSpeedSwitchingTreshold() && !_isSpeedSwitchingThresholdPassed)
            _isSpeedSwitchingThresholdPassed = true;

        if (CheckConditionForSwitchToWalkingState())
            _stateSwitcher.SwitchState<CharacterWalkingState>();
    }

    private bool CheckConditionForSwitchToWalkingState()
    {
        if (_isSpeedSwitchingThresholdPassed)
        {
            _timeAfterSwitchingThresholdPassed += Time.deltaTime;

            if (_timeAfterSwitchingThresholdPassed >= _timeToDetectNextState)
                return true;
        }

        return false;
    }

    private bool CheckSpeedSwitchingTreshold() => _reusableData.InputDirection.magnitude <= _speedSwitchingTreshold;

    public override void Exit()
    {
        base.Exit();

        _character.View.StopRunning();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        base.OnMovementCanceled(context);

        _stateSwitcher.SwitchState<CharacterNormalStoppingState>();
    }
}
