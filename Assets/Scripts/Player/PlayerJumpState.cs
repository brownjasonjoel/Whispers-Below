using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player) : base(player) { }

    public override void Enter()
    {
        base.Enter();
        anim.SetBool("isJumping", true);

        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);

        JumpPressed = false;
        JumpReleased = false;
    }


    public override void Update()
    {
        base.Update();

        if (!player.isGrounded && player.isTouchingWall && MoveInput.x == player.facingDirection && player.rb.linearVelocity.y < 0)
            player.ChangeState(player.wallSlideState);

        else if (JumpPressed && player.isTouchingWall)
            player.ChangeState(player.wallJumpState);

        else if (player.isGrounded && player.rb.linearVelocity.y <= 0)
            player.ChangeState(player.idleState);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        player.ApplyVariableGravity();

        if (JumpReleased && player.rb.linearVelocity.y > 0)
        {
            player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.rb.linearVelocity.y * player.jumpCutMultiplier);
            JumpReleased = false;
        }

        float speed = RunPressed ? player.runSpeed : player.walkSpeed;
        float targetSpeed = speed * MoveInput.x;
        player.rb.linearVelocity = new Vector2 (targetSpeed, player.rb.linearVelocity.y);

    }


    public override void Exit()
    {
        base.Exit();

        anim.SetBool("isJumping", false);
    }
}

