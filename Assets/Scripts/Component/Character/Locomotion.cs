using Service.InputService;
using UnityEngine;

namespace Component.Character
{
    public class Locomotion : CharacterState
    {
        private bool _hasJumped;
        private int _jumpCount;

        protected override void OnFixedUpdate()
        {
            if (!CharacterMachine.Controller.HasStateAuthority)
            {
                return;
            }

            Vector3 inputDirection =
                KinematicController.Data.TransformRotation * new Vector3(Input.Move.x, 0, Input.Move.y);
            KinematicController.SetInputDirection(inputDirection);

            if (KinematicController.Data.IsGrounded)
            {
                _jumpCount = 0;
            }

            _hasJumped = Input.Buttons.WasPressed(PreviousButtons, InputActions.Jump) &&
                         _jumpCount - 1 < Params.MaxInAirJumpCount;

            if (_hasJumped)
            {
                KinematicController.Jump(Vector3.up);
                _jumpCount++;
            }
        }

        protected override void OnRender()
        {
            AnimationController.VerticalMotion = Input.Move.y;
            AnimationController.HorizontalMotion = Input.Move.x;
            AnimationController.HasJumped = _hasJumped;
            AnimationController.IsGrounded = KinematicController.Data.IsGrounded;
        }
    }
}
