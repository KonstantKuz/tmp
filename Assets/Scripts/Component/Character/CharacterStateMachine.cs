using Fusion.Addons.FSM;

namespace Component.Character
{
    public class CharacterStateMachine : StateMachine<State>
    {
        public readonly CharacterController Controller;

        public CharacterStateMachine(CharacterController controller, string name, params State[] states) : base(name, states)
        {
            Controller = controller;
        }
    }
}