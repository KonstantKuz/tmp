using StaticData;
using UnityEngine;

namespace Component.Character
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private AnimationEventsHandler _eventsHandler;

        public Animator Animator => _animator;
        public AnimationEventsHandler EventsHandler => _eventsHandler;

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

        public bool HasAttacked
        {
            get => _animator.GetBool(AnimatorHash.HasAttacked);
            set => _animator.SetBool(AnimatorHash.HasAttacked, value);
        }
    }
}
