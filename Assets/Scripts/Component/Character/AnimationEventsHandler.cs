using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Component.Character
{
    public class AnimationEventsHandler : MonoBehaviour
    {
        private readonly Dictionary<string, UnityEvent> _events = new();

        public UnityEvent this[string eventName]
        {
            get
            {
                if (!_events.ContainsKey(eventName))
                {
                    _events.Add(eventName, new UnityEvent());
                }

                return _events[eventName];
            }
        }

        public void InvokeEvent(string eventName)
        {
            if (!_events.ContainsKey(eventName))
            {
                _events.Add(eventName, new UnityEvent());
            }

            _events[eventName].Invoke();
        }
    }
}
