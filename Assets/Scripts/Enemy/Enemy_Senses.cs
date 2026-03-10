using UnityEngine;

public class Enemy_Senses : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemyConfig config;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform[] wallCheck;
    [SerializeField] private Transform attackPoint;

    public bool IsAtCliff()
    {
        return !Physics2D.Raycast(groundCheck.position, Vector2.down, config.groundCheckDistance, config.groundLayer);
    }

    public bool IsHittingWall()
    {
        Vector2 dir = Vector2.right * enemy.FacingDirection;

        foreach (Transform check in wallCheck)
        {
          bool hitwall = Physics2D.Raycast(check.position, dir, config.wallCheckDistance, config.wallLayer);

            if (hitwall)
            {
                return true;
            }
        }
        return false;
    }

    public Transform GetChaseTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, config.chaseRange, config.targetLayer);

        if(!hit)
            return null;

        Player player = hit.GetComponent<Player>();
        if(player.currentState == player.deathState)
        {
            return null;
        }

        return hit.transform;
    }

    public bool IsInMeleeRange(Transform target)
    {
        if(!target)
        {
            return false;
        }

        float distance =Vector2.Distance(target.position, attackPoint.position);

        return distance <= config.meleeRange;
    }

    public bool IsInShootingRange(Transform target)
    {
        if(!target)
        {
            return false;
        }

        float distance =Vector2.Distance(target.position, attackPoint.position);

        return distance <= config.rangedRange;
    }

    private void OnDrawGizmosSelected()
    {
        //groundCheck
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * config.groundCheckDistance);

        //wallChck
        Gizmos.color = Color.blue;
        Vector3 dir = Vector2.right * enemy.FacingDirection;
        foreach (Transform check in wallCheck)
        {
            Gizmos.DrawLine(check.position, check.position + dir * config.wallCheckDistance);
        }

        //Chase Check
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,config.chaseRange);

        //Melee Check
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPoint.position, config.meleeRange);

        //Ranged Check
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, config.rangedRange);
    }

}
