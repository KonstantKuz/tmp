using Service.InputService;
using StaticData;

namespace Component.Character
{
    public class Attack : CharacterState
    {
        private bool _hasAttacked;

        private void ResetAttackedState()
        {
            _hasAttacked = false;
        }

        protected override void OnEnterState()
        {
            AnimationController.EventsHandler[AnimationEvents.AttackFinished].AddListener(ResetAttackedState);
        }

        protected override void OnExitState()
        {
            AnimationController.EventsHandler[AnimationEvents.AttackFinished].RemoveListener(ResetAttackedState);
        }

        protected override void OnFixedUpdate()
        {
            if (_hasAttacked)
            {
                return;
            }

            _hasAttacked = Input.Buttons.WasPressed(PreviousButtons, InputActions.Fire);
        }

        protected override void OnRender()
        {
            AnimationController.HasAttacked = _hasAttacked;
        }
    }
}
