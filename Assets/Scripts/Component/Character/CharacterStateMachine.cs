using Fusion.Addons.FSM;

namespace Component.Character
{
    public class CharacterStateMachine : StateMachine<State>
    {
        public readonly NetworkCharacter Controller;

        public CharacterStateMachine(NetworkCharacter controller, string name, params State[] states) : base(name, states)
        {
            Controller = controller;
        }
    }
}
