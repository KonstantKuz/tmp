using Extensions;
using Service.InputService;
using UnityEngine;

namespace Component.Character.State
{
    public class Locomotion : CharacterState
    {
        private bool _hasJumped;
        private int _jumpCount;

        private Vector3 _lookDirection;

        private float Interpolation => Time.deltaTime * 15f;

        protected override void OnFixedUpdate()
        {
            if (!CharacterMachine.Owner.HasStateAuthority)
            {
                return;
            }

            Vector3 inputDirection = new Vector3(Input.MoveDirection.x, 0, Input.MoveDirection.y);
            KinematicController.SetInputDirection(inputDirection);

            Vector3 roundedLookDirection = Input.LookDirection.ToVector3XZ();
            roundedLookDirection.x = Mathf.RoundToInt(roundedLookDirection.x);
            roundedLookDirection.z = Mathf.RoundToInt(roundedLookDirection.z);
            _lookDirection = Vector3.Lerp(_lookDirection, roundedLookDirection, Interpolation);
            KinematicController.SetLookRotation(Quaternion.LookRotation(_lookDirection));

            if (KinematicController.Data.IsGrounded)
            {
                _jumpCount = 0;
            }

            _hasJumped = Input.Buttons.WasPressed(PreviousButtons, InputActions.Jump) &&
                         _jumpCount - 1 < Params.MaxInAirJumpCount;

            if (_hasJumped)
            {
                Vector3 jumpInputSupport = inputDirection * Params.JumpInputSupportMultiplier / (_jumpCount + 1);
                KinematicController.Jump(Vector3.up + jumpInputSupport);
                _jumpCount++;
            }
        }

        protected override void OnRender()
        {
            Vector3 localDirection = Transform.InverseTransformDirection(Input.MoveDirection.ToVector3XZ());

            AnimationController.VerticalMotion =
                Mathf.Lerp(AnimationController.VerticalMotion, Mathf.RoundToInt(localDirection.z), Interpolation);

            AnimationController.HorizontalMotion =
                Mathf.Lerp(AnimationController.HorizontalMotion, Mathf.RoundToInt(localDirection.x), Interpolation);

            AnimationController.HasJumped = _hasJumped;
            AnimationController.IsGrounded = KinematicController.Data.IsGrounded;
        }
    }
}
