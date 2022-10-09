using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStoppingState : CharacterGroundedState
{
    protected CharacterStoppingConfig StoppingConfig => GroundedConfig.CharacterStoppingConfig;

    private Vector3 _startSpeed;
    private Vector3 _currentSpeed;

    private float _timeAfterStartDeceleration;

    private bool _isAutomaticRotating;

    public CharacterStoppingState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData) : base(stateSwitcher, character, reusableData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Initialize();

        _character.View.StoppingAnimationFinished += OnStoppingAnimationFinished;
        _character.View.StartStopping();
    }

    private void Initialize()
    {
        _timeAfterStartDeceleration = 0;
        _isAutomaticRotating = CheckPossibilityAutomaticRotation();

        if (_isAutomaticRotating)
        {
            _startSpeed = GetTargetRotationDirection(_reusableData.CurrentTargetRotation) * _reusableData.Speed;
        }
        else
        {
            _startSpeed = GetTargetRotationDirection(GetCurrentRotationAngle()) * _reusableData.Speed;
        }

        _currentSpeed = _startSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (_isAutomaticRotating)
            RotateTowardsTargetRotation();

        if (!IsMoving())
            return;

        DecelerateMoving();
    }

    public override void Exit()
    {
        base.Exit();

        _character.View.StoppingAnimationFinished -= OnStoppingAnimationFinished;
        _character.View.StopStopping();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        PlayerInputActions.Movement.started += OnMovementStarted;
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext obj) { }

    private void OnMovementStarted(InputAction.CallbackContext callbackContext)
    {
        _stateSwitcher.SwitchState<CharacterWalkingState>();
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        PlayerInputActions.Movement.started -= OnMovementStarted;
    }

    private bool CheckPossibilityAutomaticRotation()
    {
        if(_reusableData.PossibilityAutomaticRotationDuringStop)
         return Math.Abs(_reusableData.RotationBeforeStartMovement - _reusableData.CurrentTargetRotation) >= RotationConfig.MinAngleToCompleteRotationDuringStop;

        return false;
    }

    private void OnStoppingAnimationFinished()
    {
        _stateSwitcher.SwitchState<CharacterIdlingState>();
    }

    #region Stopping

    protected void DecelerateMoving()
    {
        _currentSpeed = _startSpeed - GetAcceleration() * _timeAfterStartDeceleration;

        _timeAfterStartDeceleration += Time.deltaTime;

        if(_timeAfterStartDeceleration > _reusableData.TimeToStop)
            _timeAfterStartDeceleration = _reusableData.TimeToStop;

        _character.Controller.Move(_currentSpeed * Time.deltaTime);
    }

    private Vector3 GetAcceleration() => _startSpeed / _reusableData.TimeToStop;

    protected bool IsMoving(float minimalVelocityLimit = 0.05f) => _currentSpeed.magnitude > minimalVelocityLimit;

    #endregion
}
