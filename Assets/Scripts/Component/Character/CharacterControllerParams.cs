using Fusion;

namespace Component.Character
{
    public struct CharacterControllerParams : INetworkStruct
    {
        public float Speed;
        public float JumpForce;
        public int MaxInAirJumpCount;
    }
}
