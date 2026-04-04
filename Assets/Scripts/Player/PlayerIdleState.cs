using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player) : base(player) { }

    public override void Enter()
    {
        base.Enter();

        anim.SetBool("isIdle", true);
        player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y);
    }


    public override void Update()
    {
        base.Update();

        if(SpellcastPressed && magic.CanCast(magic.CurrentSpell))
        {
            player.ChangeState(player.spellcastState);
        }
        else if(AttackPressed && combat.CanAttack)
        {
            player.ChangeState(player.attackState);
        }
        else if (JumpPressed)
        {
            JumpPressed = false;
            player.ChangeState(player.jumpState);
        }
        else if (Mathf.Abs(MoveInput.x) > 0.1f)
        {
            player.ChangeState(player.moveState);
        }
        else if(MoveInput.y < -0.1f)
        {
            player.ChangeState(player.crouchState);
        }
        
    }




    public override void Exit()
    {
        base.Exit();

        anim.SetBool("isIdle", false);
    }

}
