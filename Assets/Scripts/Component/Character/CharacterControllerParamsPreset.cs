using UnityEngine;

namespace Component.Character
{
    [CreateAssetMenu(
        menuName = GlobalSettings.ScriptableObjectsPath + nameof(CharacterControllerParamsPreset),
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

        public CharacterControllerParams Value => new CharacterControllerParams
        {
            Speed = moveSpeed,
            JumpForce = jumpForce,
            MaxInAirJumpCount = maxInAirJumpCount
        };
    }
}