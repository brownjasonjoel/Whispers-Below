using UnityEngine;

public class IdleState : State
{
    private Transform target;
    protected override string AnimBoolName => "isIdling";

    public IdleState(Enemy enemy) : base(enemy) { }


    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = Vector2.zero;
    }
    public override void FixedUpdate()
    {
        //1. check for target
        target = senses.GetChaseTarget();

        if (!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }

        enemy.FaceTarget(target);

        //2. check if we can attack
        if (senses.IsInMeleeRange(target) && combat.CanMeleeAttack())
        {
            stateMachine.ChangeState(new MeleeAtackState(enemy));
            return;
        }

        //3. check if we have reached our target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);

        if (distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //4. check for obstacles
        if (senses.IsHittingWall() || senses.IsAtCliff())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        //5.we have a target, we have not reached it, there are no obstacles
        stateMachine.ChangeState(new ChaseState(enemy));
    }




}
