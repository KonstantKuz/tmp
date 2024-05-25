using StaticData;
using UnityEngine;

namespace Component.Character
{
    [CreateAssetMenu(
        menuName = SettingsPath.ScriptableObjects + nameof(CharacterControllerParamsPreset),
        fileName = nameof(CharacterControllerParamsPreset)
    )]
    public class CharacterControllerParamsPreset : ScriptableObject
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private int maxInAirJumpCount;

        [SerializeField]
        private float rootMotionSpeedMultiplier;

        [SerializeField]
        private float jumpInputSupportMultiplier;

        public NetworkCharacterParams Value => new()
        {
            Speed = moveSpeed,
            JumpForce = jumpForce,
            MaxInAirJumpCount = maxInAirJumpCount,
            RootMotionSpeedMultiplier = rootMotionSpeedMultiplier,
            JumpInputSupportMultiplier = jumpInputSupportMultiplier,
        };
    }
}
