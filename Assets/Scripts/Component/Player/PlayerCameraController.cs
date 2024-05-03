using System.Linq;
using UnityEngine;

namespace Component.Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        private PlayerCharacterController _player;
        private Vector3 _offset;

        private void LateUpdate()
        {
            if (_player == null)
            {
                _player = FindObjectsOfType<PlayerCharacterController>().FirstOrDefault(item => item.HasInputAuthority);
                if (_player != null)
                {
                    _offset = _player.transform.position - transform.position;
                }
            }

            if (_player != null)
            {
                transform.position = _player.transform.position - _offset;
            }
        }
    }
}
