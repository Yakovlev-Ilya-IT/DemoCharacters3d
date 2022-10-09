using System;
using System.Collections;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private Animator _animator;
    private AnimationsDataHash _animationsDataHash;

    public event Action StoppingAnimationFinished;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _animationsDataHash = new AnimationsDataHash();
    }

    public void StartMovement() => _animator.SetBool(_animationsDataHash.IsMovementHash, true);
    public void StopMovement() => _animator.SetBool(_animationsDataHash.IsMovementHash, false);
    public void StartGrounded() => _animator.SetBool(_animationsDataHash.IsGroundedHash, true);
    public void StopGrounded() => _animator.SetBool(_animationsDataHash.IsGroundedHash, false);
    public void StartMoving() => _animator.SetBool(_animationsDataHash.IsMovingHash, true);
    public void StopMoving() => _animator.SetBool(_animationsDataHash.IsMovingHash, false);
    public void StartWalking() => _animator.SetBool(_animationsDataHash.IsWalkingHash, true);
    public void StopWalking() => _animator.SetBool(_animationsDataHash.IsWalkingHash, false);
    public void StartRunning() => _animator.SetBool(_animationsDataHash.IsRunningHash, true);
    public void StopRunning() => _animator.SetBool(_animationsDataHash.IsRunningHash, false);
    public void StartStopping() => _animator.SetBool(_animationsDataHash.IsStoppingHash, true);
    public void StopStopping() => _animator.SetBool(_animationsDataHash.IsStoppingHash, false);
    public void StartMediumStopping() => _animator.SetBool(_animationsDataHash.IsMediumStoppingHash, true);
    public void StopMediumStopping() => _animator.SetBool(_animationsDataHash.IsMediumStoppingHash, false);
    public void StartIdling() => _animator.SetBool(_animationsDataHash.IsIdlingHash, true);
    public void StopIdling() => _animator.SetBool(_animationsDataHash.IsIdlingHash, false);

    public void OnStoppingAnimvationComplete()
    {
        StoppingAnimationFinished?.Invoke();
    }
}
