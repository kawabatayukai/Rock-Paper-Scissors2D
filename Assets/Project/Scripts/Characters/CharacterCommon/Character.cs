using UnityEngine;

// キャラクター基底クラス
// 移動、接地判定・向きの変更をまとめる

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker))] 
public class Character : MonoBehaviour
{
    CharacterMovement characterMovement;
    GroundChecker groundChecker;

    protected CharacterMovement.MovementInput input;
    public CharacterMovement.MovementParameter Param
    {
        get
        {
            return characterMovement.Param;
        }
        set
        {
            characterMovement.Param = value;
        }
    }

    protected virtual void Start()
    {
        characterMovement = new CharacterMovement(GetComponent<Rigidbody2D>());
        input = CharacterMovement.MovementInput.none;
        groundChecker = GetComponent<GroundChecker>();
    }

    protected virtual void Update()
    {
        input.direction = Vector2.zero;
    }

    protected virtual void FixedUpdate()
    {
        ApplyMovment();
        ApplyDirection();
        input.jump = false;
    }

    // 移動を適用
    private void ApplyMovment()
    {
        if (!input.EnableInput) { return; }

        characterMovement.Move(input.direction);
        if (groundChecker.IsGround)
        {
            characterMovement.Jump(input.jump);
        }
    }

    // 進行方向を向く
    private void ApplyDirection()
    {
        if (input.direction == Vector2.zero) { return; }
        transform.localScale = characterMovement.GetLocalScaleToUpdateDirection(input.direction);
    }
}
