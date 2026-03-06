using UnityEngine;

public class MeleeAtackState : State
{
    protected override string AnimBoolName => "isAttacking";

    public MeleeAtackState(Enemy enemy): base(enemy) { }


    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = Vector2.zero;
    }


    public override void OnAnimationFinished()
    { 
    stateMachine.ChangeState(new IdleState(enemy));
    }

}
