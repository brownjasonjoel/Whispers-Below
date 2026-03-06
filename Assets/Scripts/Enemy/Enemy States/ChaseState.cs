using UnityEngine;

public class ChaseState : State
{
    private Transform target;
    protected override string AnimBoolName => "isRunning";
    
    public ChaseState(Enemy enemy) : base(enemy) { }


    public override void FixedUpdate()
    {
        //1. check for target
        target = senses.GetChaseTarget();

        if(!target)
        {
            stateMachine.ChangeState(new PatrolState(enemy));
            return;
        }

        enemy.FaceTarget(target);

        //2. check if we can attack
        if(senses.IsInMeleeRange(target) && combat.CanMeleeAttack())
        {
            stateMachine.ChangeState(new MeleeAtackState(enemy));
            return;
        }

        //3. check if we have reached our target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);

        if(distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //4. check for obstacles
        if (senses.IsHittingWall() || senses.IsAtCliff())
        {
           stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //5. move toward target
        rb.linearVelocity = new Vector2( config.chaseSpeed * enemy.FacingDirection,rb.linearVelocity.y) ;
    }

    public override void Exit()
    {
        base.Exit();
        rb.linearVelocity = Vector2.zero;
    }



}
