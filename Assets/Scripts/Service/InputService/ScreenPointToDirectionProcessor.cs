using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Service.InputService
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class ScreenPointToDirectionProcessor : InputProcessor<Vector2>
    {
#if UNITY_EDITOR
        static ScreenPointToDirectionProcessor()
        {
            Initialize();
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<ScreenPointToDirectionProcessor>();
        }

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            return (value - new Vector2(Screen.width / 2f, Screen.height / 2f)).normalized;
        }
    }
}
