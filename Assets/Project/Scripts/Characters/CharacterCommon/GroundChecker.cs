using System.Collections.Generic;
using UnityEngine;

// �ڒn����
// �ڐG�_�̖@���x�N�g���Ə�����x�N�g�����r

// �Ethreshold�̖ڈ�
//   -> 0f :�n�ʂƊ��S�ɐ���,   0.5f :��60�x�̌X�΂܂Őڒn�Ɣ���
// �E�ڐG����Collider�Q��
// �@-> �v�f��0�̂Ƃ��ɐڒn�Ȃ�

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
                // �ڐG����Collider��������
                isGround = true;
                TryAddCollider(collision.collider);
                return;
            }
        }
        // �ڐG�ʂȂ�
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
