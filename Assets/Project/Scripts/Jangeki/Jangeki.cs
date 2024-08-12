using UnityEngine;

// Paramを操作すればあらゆる動きに対応できるように

public class Jangeki : MonoBehaviour
{
    public enum Type
    {
        None = 0,
        Rock,
        Scissors,
        Paper
    }
    protected Type type;
    protected SpriteRenderer spriteRenderer;
    protected JangekiMovement jangekiMovement;

    public JangekiMovement.MovementParameter Param { get {  return jangekiMovement.Param; } set { jangekiMovement.Param = value; } }

    protected virtual void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        jangekiMovement = new JangekiMovement(GetComponent<Rigidbody2D>());
    }

    protected virtual void Start()
    {
    }

    protected virtual void FixedUpdate()
    {
        ApplyMovment();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        // プールに戻る
        if (collision.gameObject.layer == LayerMask.NameToLayer("JangekiEraser"))
        {
            EraseSelf();
            return;
        }
    }

    protected void EraseSelf()
    {
        gameObject.SetActive(false);
    }

    private void ApplyMovment()
    {
        jangekiMovement.Move();
    }

    public virtual void SetSprite(Sprite sprite)
    {
        if(sprite is null) { return; }
        this.spriteRenderer.sprite = sprite;
    }
}
