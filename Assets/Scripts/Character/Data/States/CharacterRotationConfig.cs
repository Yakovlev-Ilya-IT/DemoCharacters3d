using System;
using UnityEngine;

[Serializable]
public class CharacterRotationConfig
{
    [SerializeField, Range(0, 1)] private float _timeToReachTargetRotation = 0.15f;
    [SerializeField, Range(0, 180)] private float _minAngleToCompleteRotationDuringStop = 90;
    [SerializeField, Range(0, 0.5f)] private float _inputTimeForPossibilityAutomaticRotation = 0.2f;
    public float TimeToReachTargetRotation => _timeToReachTargetRotation;
    public float MinAngleToCompleteRotationDuringStop => _minAngleToCompleteRotationDuringStop;
    public float InputTimeForPossibilityAutomaticRotation => _inputTimeForPossibilityAutomaticRotation;
}
