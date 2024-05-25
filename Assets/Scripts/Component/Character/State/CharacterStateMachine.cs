using Fusion.Addons.FSM;

namespace Component.Character.State
{
    public class CharacterStateMachine : StateMachine<Fusion.Addons.FSM.State>
    {
        public readonly NetworkCharacter Owner;

        public CharacterStateMachine(NetworkCharacter owner, string name, params Fusion.Addons.FSM.State[] states) : base(name, states)
        {
            Owner = owner;
        }
    }
}
