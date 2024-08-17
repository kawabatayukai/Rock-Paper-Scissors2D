using UnityEditor;
using UnityEngine;

// 巡回ポイント

namespace PatrolSystem
{
    public class PatrolPoint : MonoBehaviour
    {
        [SerializeField]
        int number;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.1f);
            Gizmos.DrawLine(transform.position, transform.position + (Vector3.up * 1f));
            Gizmos.DrawSphere(transform.position + (Vector3.up * 1f), 0.15f);
        }
    }
}


