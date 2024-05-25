using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 ToVector2XZ(this Vector3 vector3)
        {
            return new (vector3.x, vector3.z);
        }

        public static Vector3 ToVector3XZ(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }
    }
}
