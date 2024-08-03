using System.Collections.Generic;
using UnityEngine;

// 接地判定
// 接触点の法線ベクトルと上方向ベクトルを比較

// ・thresholdの目安
//   -> 0f :地面と完全に垂直,   0.5f :約60度の傾斜まで接地と判定
// ・接触中のCollider参照
// 　-> 要素数0のときに接地なし

public class GroundChecker : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    float threshold = 0.5f;
    List<Collider2D> enterColliders;

    bool isGround;
    public bool IsGround { get { return isGround; } }

    private void Start()
    {
        enterColliders = new List<Collider2D>();
    }

    private void TryAddCollider(Collider2D collider)
    {
        if (enterColliders.Contains(collider)) { return; }
        enterColliders.Add(collider);
    }
    private void TryRemoveCollider(Collider2D collider)
    {
        if (!enterColliders.Contains(collider)) { return; }
        enterColliders.Remove(collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D contactPoint in collision.contacts)
        {
            if (Vector2.Dot(contactPoint.normal, Vector2.up) > threshold) 
            {
                TryAddCollider(collision.collider);
            }
            isGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if (Vector2.Dot(contactPoint.normal, Vector2.up) > threshold)
            {
                // 接触中のColliderがある状態
                isGround = true;
                TryAddCollider(collision.collider);
                return;
            }
        }
        // 接触面なし
        TryRemoveCollider(collision.collider);
        if (enterColliders.Count <= 0) 
        {
            isGround = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        TryRemoveCollider(collision.collider);
        if (enterColliders.Count <= 0)
        {
            isGround = false;
        }
    }
}
