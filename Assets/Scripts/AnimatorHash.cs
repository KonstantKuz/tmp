using UnityEngine;

public class AnimatorHash
{
    public static readonly int HorizontalMotion = Animator.StringToHash("HorizontalMotion");
    public static readonly int VerticalMotion = Animator.StringToHash("VerticalMotion");
    public static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    public static readonly int HasJumped = Animator.StringToHash("HasJumped");
}
