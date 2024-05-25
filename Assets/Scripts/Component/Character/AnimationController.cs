using StaticData;
using UnityEngine;

namespace Component.Character
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimationEventsHandler events;

        public Animator Animator => _animator;
        public AnimationEventsHandler Events => events;

        public float VerticalMotion
        {
            get => _animator.GetFloat(AnimatorHash.VerticalMotion);
            set
            {
                _animator.SetFloat(AnimatorHash.VerticalMotion, value);
                VerticalMotionNormalized = Mathf.RoundToInt(value);
            }
        }

        public float HorizontalMotion
        {
            get => _animator.GetFloat(AnimatorHash.HorizontalMotion);
            set
            {
                _animator.SetFloat(AnimatorHash.HorizontalMotion, value);
                HorizontalMotionNormalized = Mathf.RoundToInt(value);
            }
        }

        public int VerticalMotionNormalized
        {
            get => _animator.GetInteger(AnimatorHash.VerticalMotionNormalized);
            private set => _animator.SetInteger(AnimatorHash.VerticalMotionNormalized, value);
        }

        public int HorizontalMotionNormalized
        {
            get => _animator.GetInteger(AnimatorHash.HorizontalMotionNormalized);
            private set => _animator.SetInteger(AnimatorHash.HorizontalMotionNormalized, value);
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

        public bool HasAttacked
        {
            get => _animator.GetBool(AnimatorHash.HasAttacked);
            set => _animator.SetBool(AnimatorHash.HasAttacked, value);
        }
    }
}
