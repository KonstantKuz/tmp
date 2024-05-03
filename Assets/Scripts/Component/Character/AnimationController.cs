using UnityEngine;

namespace Component.Character
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        public float VerticalMotion
        {
            get => _animator.GetFloat(AnimatorHash.VerticalMotion);
            set => _animator.SetFloat(AnimatorHash.VerticalMotion, value);
        }

        public float HorizontalMotion
        {
            get => _animator.GetFloat(AnimatorHash.HorizontalMotion);
            set => _animator.SetFloat(AnimatorHash.HorizontalMotion, value);
        }

        public bool IsGrounded
        {
            get => _animator.GetBool(AnimatorHash.IsGrounded);
            set => _animator.SetBool(AnimatorHash.IsGrounded, value);
        }

        public bool HasJumped
        {
            get => _animator.GetBool(AnimatorHash.HasJumped);
            set => _animator.SetBool(AnimatorHash.HasJumped, value);
        }
    }
}
