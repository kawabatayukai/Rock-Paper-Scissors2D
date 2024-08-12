using UnityEngine;

// 派生先では、Paramを操作するだけで挙動を実現できる実装が必要

public class JangekiMovement
{
    //public class MovementParameter
    //{
    //    public float speed;
    //    public Vector2 direction;

    //    public Vector2 GetDirection(float radiansAngle)
    //    {
    //        return new Vector2(Mathf.Cos(radiansAngle), Mathf.Sin(radiansAngle));
    //    }
    //}

    JangekiParameter.MovementParameter param;
    Rigidbody2D rigidbody;

    public JangekiParameter.MovementParameter Param
    {
        get { return param; }
        set { param = value; }
    }


    public JangekiMovement(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
        if (rigidbody is null) 
        {
            throw new System.ArgumentNullException("JangekiMovement: Rigidbody2D is null!");
        }
    }

    public void Move()
    {
        if (param is null)     { return; }
        if (rigidbody is null) { return; }

        rigidbody.velocity = param.direction * param.speed * Time.fixedDeltaTime;
    }
}