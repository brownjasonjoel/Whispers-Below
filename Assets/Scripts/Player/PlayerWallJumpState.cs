using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    private float horizontalJumpPercent = 0.5f;

    public PlayerWallJumpState(Player player) : base(player) { }

    public override void Enter()
    {
        anim.SetBool("isWallJumping", true);

        player.rb.linearVelocity = Vector2.zero;
        player.rb.linearVelocity = new Vector2(-player.facingDirection * horizontalJumpPercent, 1f) * player.jumpForce;

        JumpPressed = false;
        JumpReleased = false;
    }

    public override void Update()
    {

        if (!player.isGrounded && player.isTouchingWall && MoveInput.x == player.facingDirection && player.rb.linearVelocity.y < 0)
            player.ChangeState(player.wallSlideState);

        else if(JumpPressed && player.isTouchingWall)
            player.ChangeState(player.wallJumpState);

        else if(player.isGrounded && player.rb.linearVelocity.y <= .1f)
            player.ChangeState(player.idleState);
    
    }

    public override void FixedUpdate()
    {
        player.ApplyVariableGravity();

        if(JumpReleased && player.rb.linearVelocity.y > 0 )
        {
            player.rb.linearVelocity = new Vector2 (player.rb.linearVelocity.x, player.rb.linearVelocity.y * player.jumpCutMultiplier);
            JumpPressed = false;
        }
    }

    public override void Exit()
    {
        anim.SetBool("isWallJumping", false);
    }
}
