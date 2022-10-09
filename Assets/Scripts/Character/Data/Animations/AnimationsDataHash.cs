using UnityEngine;

public class AnimationsDataHash
{
    private const string IsMovement = "IsMovement";
    private const string IsGrounded = "IsGrounded";
    private const string IsMoving = "IsMoving";
    private const string IsWalking = "IsWalking";
    private const string IsRunning = "IsRunning";
    private const string IsStopping = "IsStopping";
    private const string IsMediumStopping = "IsMediumStopping";
    private const string IsIdling = "IsIdling";

    public int IsMovementHash { get; }
    public int IsGroundedHash { get; }
    public int IsMovingHash { get; }
    public int IsWalkingHash { get; }
    public int IsRunningHash { get; }
    public int IsStoppingHash { get; }
    public int IsMediumStoppingHash { get; }
    public int IsIdlingHash { get; }

    public AnimationsDataHash()
    {
        IsMovementHash = Animator.StringToHash(IsMovement);
        IsGroundedHash = Animator.StringToHash(IsGrounded);
        IsMovingHash = Animator.StringToHash(IsMoving);
        IsWalkingHash = Animator.StringToHash(IsWalking);
        IsRunningHash = Animator.StringToHash(IsRunning);
        IsStoppingHash = Animator.StringToHash(IsStopping);
        IsMediumStoppingHash = Animator.StringToHash(IsMediumStopping);
        IsIdlingHash = Animator.StringToHash(IsIdling);
    }
}
