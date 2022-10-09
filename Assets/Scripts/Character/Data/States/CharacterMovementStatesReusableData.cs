using UnityEngine;

public class CharacterMovementStatesReusableData
{
    private Vector2 _inputDirection;

    private float _speed;

    private float _rotationBeforeStartMovement;
    private bool _possibilityAutomaticRotationDuringStop;

    private float _currentTargetRotation;
    private float _timeToReachTargetRotation;
    private float _dampedTargetRotationCurrentVelocity;
    private float _dampedTargetRotationPassedTime;

    private float _timeToStop;

    public Vector2 InputDirection
    {
        get => _inputDirection;
        set => _inputDirection = value;
    }

    public float Speed
    {
        get { return _speed; }
        set
        {
            if(value >= 0)
                _speed = value;
            else
                Debug.LogError($"ArgumentOutOfRangeException: {value}");
        }
    }

    public float RotationBeforeStartMovement
    {
        get => _rotationBeforeStartMovement;
        set => _rotationBeforeStartMovement = value;
    }

    public bool PossibilityAutomaticRotationDuringStop
    {
        get => _possibilityAutomaticRotationDuringStop;
        set => _possibilityAutomaticRotationDuringStop = value;
    }
    public float CurrentTargetRotation
    {
        get { return _currentTargetRotation; }
        set
        {
            if (value >= 0)
                _currentTargetRotation = value;
            else
                Debug.LogError($"ArgumentOutOfRangeException: {value}");
        }
    }
    public float TimeToReachTargetRotation
    {
        get { return _timeToReachTargetRotation; }
        set
        {
            if (value >= 0)
                _timeToReachTargetRotation = value;
            else
                Debug.LogError($"ArgumentOutOfRangeException: {value}");
        }
    }
    public ref float DampedTargetRotationCurrentVelocity
    {
        get { return ref _dampedTargetRotationCurrentVelocity; }
    }
    public float DampedTargetRotationPassedTime
    {
        get { return _dampedTargetRotationPassedTime; }
        set
        {
            if (value >= 0)
                _dampedTargetRotationPassedTime = value;
            else
                Debug.LogError($"ArgumentOutOfRangeException: {value}");
        }
    }

    public float TimeToStop
    {
        get { return _timeToStop; }
        set
        {
            if(value >= 0)
                _timeToStop = value;
            else
                Debug.LogError($"ArgumentOutOfRangeException: {value}");
        }
    }
}
