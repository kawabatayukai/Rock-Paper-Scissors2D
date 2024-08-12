using System;
using UnityEngine;

namespace JangekiParameter
{
    // インスペクタ設定用
    [Serializable]
    public class InitializeParameter
    {
        [SerializeField] public Transform launchPosition;
        [SerializeField] public Vector3 localScele = Vector3.one;
        [SerializeField] public float speed = 50.0f;
    }

    public class MovementParameter
    {
        public float speed;
        public Vector2 direction;

        public Vector2 GetDirection(float radiansAngle)
        {
            return new Vector2(Mathf.Cos(radiansAngle), Mathf.Sin(radiansAngle));
        }
    }
}
