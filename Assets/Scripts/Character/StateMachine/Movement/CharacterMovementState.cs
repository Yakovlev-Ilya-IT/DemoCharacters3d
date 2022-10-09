using UnityEngine;

public abstract class CharacterMovementState : IState
{
    protected readonly IStationStateSwitcher _stateSwitcher;
    protected readonly Character _character;

    protected CharacterMovementStatesReusableData _reusableData;
    protected CharacterGroundedConfig GroundedConfig => _character.Config.CharacterGroundedConfig;
    protected CharacterRotationConfig RotationConfig => GroundedConfig.CharacterRotationConfig;

    protected PlayerInput.PlayerActions PlayerInputActions => _character.Input.PlayerActions;

    public CharacterMovementState(IStationStateSwitcher stateSwitcher, Character character, CharacterMovementStatesReusableData reusableData)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _reusableData = reusableData;

        Initialize();
    }

    private void Initialize()
    {
        _reusableData.TimeToReachTargetRotation = RotationConfig.TimeToReachTargetRotation;
    }

    public virtual void Enter()
    {
        Debug.Log($"State: {GetType().Name}");

        AddInputActionsCallbacks();

        _character.View.StartMovement();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();

        _character.View.StopMovement();
    }

    public virtual void HandleInput()
    {
        _reusableData.InputDirection = ReadMovementInput();
    }

    public virtual void Update()
    {
        if (CheckInputIsZero())
            return;

        Vector3 convertedInputDirection = GetConvertedInputDirection();
        float inputAngleDirection = GetDirectionAngle(convertedInputDirection);

        Move(convertedInputDirection);
        Rotate(inputAngleDirection);
    }

    protected virtual void AddInputActionsCallbacks() { }

    protected virtual void RemoveInputActionsCallbacks() { }

    #region Move

    private void Move(Vector3 inputDirection)
    {
        float scaledMoveSpeed = GetScaledMoveSpeed();

        Vector3 normalizedInputDirection = inputDirection.normalized;

        _character.Controller.Move(normalizedInputDirection * scaledMoveSpeed);
    }

    protected float GetScaledMoveSpeed() => _reusableData.Speed * Time.deltaTime;

    #endregion

    #region Rotate

    public void Rotate(float inputAngleDirection)
    {
        if (inputAngleDirection != _reusableData.CurrentTargetRotation)
            UpdateTargetRotationData(inputAngleDirection);

        RotateTowardsTargetRotation();
    }

    private void UpdateTargetRotationData(float targetAngle)
    {
        _reusableData.CurrentTargetRotation = targetAngle;
        _reusableData.DampedTargetRotationPassedTime = 0f;
    }

    protected void RotateTowardsTargetRotation()
    {
        float currentYAngle = GetCurrentRotationAngle();

        if (currentYAngle == _reusableData.CurrentTargetRotation)
            return;

        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, _reusableData.CurrentTargetRotation, ref _reusableData.DampedTargetRotationCurrentVelocity, _reusableData.TimeToReachTargetRotation - _reusableData.DampedTargetRotationPassedTime);
        _reusableData.DampedTargetRotationPassedTime += Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0, smoothedYAngle, 0);
        _character.transform.rotation = targetRotation;
    }

    protected float GetCurrentRotationAngle() => _character.transform.rotation.eulerAngles.y;

    #endregion

    #region Input

    private Vector2 ReadMovementInput() => PlayerInputActions.Movement.ReadValue<Vector2>();
    protected Vector3 GetConvertedInputDirection() => new Vector3(_reusableData.InputDirection.x, 0, _reusableData.InputDirection.y);
    protected bool CheckInputIsZero() => _reusableData.InputDirection == Vector2.zero;
    protected Vector3 GetTargetRotationDirection(float targetAngle) => Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
    protected float GetDirectionAngle(Vector3 inputMoveDirection)
    {
        float directionAngle = Mathf.Atan2(inputMoveDirection.x, inputMoveDirection.z) * Mathf.Rad2Deg;

        if (directionAngle < 0)
            directionAngle += 360;

        return directionAngle;
    }

    #endregion
}
