using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMovement characterMovement;
    CharacterMovement.MovementInput input;
    GroundChecker groundChecker;

    private void Start()
    {
        characterMovement = new CharacterMovement(GetComponent<Rigidbody2D>());
        characterMovement.Param = new CharacterMovement.MovementParameter(3.0f, 10.0f);
        input = CharacterMovement.MovementInput.none;
        groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        input.direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) { input.direction = Vector2.left; }
        if (Input.GetKey(KeyCode.D)) { input.direction = Vector2.right; }
        if (Input.GetKeyDown(KeyCode.Space)) { input.jump = true; }
        
    }

    private void FixedUpdate()
    {
        ApplyMovment();
        ApplyDirection();
        input.jump = false;
    }

    // 移動を適用
    private void ApplyMovment()
    {
        if(!input.EnableInput) { return; }

        characterMovement.Move(input.direction);
        if (groundChecker.IsGround)
        {
            characterMovement.Jump(input.jump);
        }
    }

    // 進行方向を向く
    private void ApplyDirection()
    {
        if(input.direction == Vector2.zero) { return; }
        transform.localScale = characterMovement.GetLocalScaleToUpdateDirection(input.direction);
    }
}
