using UnityEngine;

// �L�����N�^�[���N���X
// �ړ��A�ڒn����E�����̕ύX���܂Ƃ߂�

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

    // �ړ���K�p
    private void ApplyMovment()
    {
        if (!input.EnableInput) { return; }

        characterMovement.Move(input.direction);
        if (groundChecker.IsGround)
        {
            characterMovement.Jump(input.jump);
        }
    }

    // �i�s����������
    private void ApplyDirection()
    {
        if (input.direction == Vector2.zero) { return; }
        transform.localScale = characterMovement.GetLocalScaleToUpdateDirection(input.direction);
    }
}
