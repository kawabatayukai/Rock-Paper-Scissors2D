using UnityEngine;

public class PlayerController : Character
{
    JangekiLauncher jangekiLauncher;

    protected sealed override void Start()
    {
        base.Start();
        jangekiLauncher = GetComponent<JangekiLauncher>();
    }

    protected sealed override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.A)) { input.direction = Vector2.left; }
        if (Input.GetKey(KeyCode.D)) { input.direction = Vector2.right; }
        if (Input.GetKeyDown(KeyCode.Space)) { input.jump = true; }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Jangeki jangeki = jangekiLauncher.Launch(Jangeki.Type.Rock);
            JangekiParameter.MovementParameter param = new JangekiParameter.MovementParameter();
            param.speed = 50.0f;
            param.direction = transform.right * transform.localScale.x;
            jangeki.Param = param;
        }
    }

    protected sealed override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
