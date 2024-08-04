using UnityEngine;

public class PlayerController : Character
{
    sealed protected override void Start()
    {
        base.Start();
    }

   sealed protected override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.A)) { input.direction = Vector2.left; }
        if (Input.GetKey(KeyCode.D)) { input.direction = Vector2.right; }
        if (Input.GetKeyDown(KeyCode.Space)) { input.jump = true; }
    }

    sealed protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
