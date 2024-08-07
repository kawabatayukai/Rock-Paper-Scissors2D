using UnityEngine;

// 移動・ジャンプ担当

public class CharacterMovement 
{
    public struct MovementParameter
    {
        public readonly float speed;
        public readonly float jumpForce;
        public MovementParameter(float speed, float jumpForce)
        {
            this.speed = speed;
            this.jumpForce = jumpForce;
        }
    }
    public struct MovementInput
    {
        public Vector2 direction;
        public bool jump;

        public static MovementInput none = new MovementInput(Vector2.zero, false);

        public MovementInput(Vector2 direction, bool jump)
        {
            this.direction = direction;
            this.jump = jump;
        }
        public bool EnableInput 
        { 
            get
            {
                if(direction == Vector2.zero && !jump)
                {
                    return false;
                }

                return true;
            }
        }
    }

    MovementParameter param = new MovementParameter(3.0f, 10.0f);
    Rigidbody2D rigidbody;
    
    public MovementParameter Param
    { 
        get 
        { 
            return param; 
        }
        set
        {
            param = value;
        }
    }


    public CharacterMovement(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
        if (!rigidbody)
        {
            throw new System.ArgumentNullException("Rigidbody2D is null!");
        }
    }

    public void Move(Vector2 direction)
    {
        if (!rigidbody) { return; }

        Vector2 velocity = rigidbody.velocity;
        velocity.x = direction.x * param.speed;
        rigidbody.velocity = velocity;
    }

    public void Jump(bool jump)
    {
        if (!jump) { return; }
        if (!rigidbody) { return; }

        rigidbody.AddForce(Vector2.up * param.jumpForce, ForceMode2D.Impulse);
    }

    public Vector3 GetLocalScaleToUpdateDirection(Vector2 direction)
    {
        if(direction.x < 0)
        {
            return new Vector3(-1, 1, 1);
        }
        if (direction.x > 0)
        {
            return new Vector3(1, 1, 1);
        }
        return new Vector3(1, 1, 1);
    }
}
