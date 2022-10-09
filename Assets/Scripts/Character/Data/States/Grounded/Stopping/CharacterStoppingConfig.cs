using System;
using UnityEngine;

[Serializable]
public class CharacterStoppingConfig
{
    [SerializeField, Range(0, 1)] private float _timeToLightStop = 0.1f;
    [SerializeField, Range(0, 1)] private float _timeToNormalStop = 0.2f;
    public float TimeToLightStop => _timeToLightStop;
    public float TimeToNormalStop => _timeToNormalStop;
}