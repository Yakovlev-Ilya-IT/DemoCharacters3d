using System;
using UnityEngine;

[Serializable]
public class CharacterGroundedConfig
{
    [SerializeField, Range(1,20)] private float _walkingSpeed = 2f;
    [SerializeField, Range(1,20)] private float _runningSpeed = 5f;
    [SerializeField, Range(0.1f, 0.9f)] private float _inputThresholdForSwitchingSpeed = 0.5f;
    [SerializeField] private CharacterRotationConfig _characterRotationConfig;
    [SerializeField] private CharacterStoppingConfig _characterStoppingConfig;
    
    public float WalkingSpeed => _walkingSpeed;
    public float RunningSpeed => _runningSpeed;
    public float InputThresholdForSwitchingSpeed => _inputThresholdForSwitchingSpeed;
    public CharacterRotationConfig CharacterRotationConfig => _characterRotationConfig;
    public CharacterStoppingConfig CharacterStoppingConfig => _characterStoppingConfig;
}
