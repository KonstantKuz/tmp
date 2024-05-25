using Service.InputService;
using StaticData;
using UnityEngine;

namespace Component.Character.State
{
    public class Attack : CharacterState
    {
        private bool _isAttacking;
        private Vector3 _accumulatedAnimatorDelta;

        protected override void OnEnterState()
        {
            AnimationController.Events[AnimationEvents.OnAnimatorMove].AddListener(OnAnimatorMove);
            AnimationController.Events[AnimationEvents.AttackFinished].AddListener(OnAttackFinished);
        }

        protected override void OnExitState()
        {
            AnimationController.Events[AnimationEvents.OnAnimatorMove].RemoveListener(OnAnimatorMove);
            AnimationController.Events[AnimationEvents.AttackFinished].RemoveListener(OnAttackFinished);
        }

        private void OnAnimatorMove()
        {
            if (_isAttacking)
            {
                _accumulatedAnimatorDelta +=
                    AnimationController.Animator.deltaPosition * Params.RootMotionSpeedMultiplier;

                _accumulatedAnimatorDelta =
                    KinematicController.transform.InverseTransformDirection(_accumulatedAnimatorDelta);

                _accumulatedAnimatorDelta.z = _accumulatedAnimatorDelta.z < 0 ? 0 : _accumulatedAnimatorDelta.z;
                _accumulatedAnimatorDelta.x = 0;

                _accumulatedAnimatorDelta = KinematicController.transform.TransformDirection(_accumulatedAnimatorDelta);
            }
        }

        private void OnAttackFinished()
        {
            _isAttacking = false;
        }

        protected override void OnFixedUpdate()
        {
            if (!CharacterMachine.Owner.HasStateAuthority)
            {
                return;
            }

            if (!_isAttacking)
            {
                _isAttacking = Input.Buttons.IsSet(InputActions.Fire) && KinematicController.Data.IsGrounded;
            }

            if (_isAttacking)
            {
                KinematicController.SetInputDirection(_accumulatedAnimatorDelta);
                _accumulatedAnimatorDelta = Vector3.zero;
            }
        }

        protected override void OnRender()
        {
            if (AnimationController.HasAttacked != _isAttacking)
            {
                AnimationController.HasAttacked = _isAttacking;
            }
        }
    }
}
