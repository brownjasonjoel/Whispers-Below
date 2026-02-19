using UnityEngine;

public class PlayerCrouchState : PlayerState
{
    public PlayerCrouchState(Player player) : base(player) { }




    public override void Enter()
    {
        base.Enter();

        anim.SetBool("isCrouching", true);

    }







    public override void Exit()
    {
        base.Exit();

        anim.SetBool("isCrouching", false);
    }




}
