using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{

    [Header("General")]
    public float turnThreshold = 0.2f;
        
    [Header("Patrol")]
    public float patrolSpeed = 5f;
    public float groundCheckDistance = 0.7f;
    public float wallCheckDistance = 0.5f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    [Header("Chase")]
    public float chaseSpeed = 7f;
    public float chaseRange = 5f;
    public LayerMask targetLayer;

    [Header("Attack")]
    public float meleeRange = 1.2f;
    public int meleeDamage = 2;
    public float meleeCooldown = 1;

    [Header("Ranged Attack")]
    public float rangedRange = 5f;
    public int rangedDamage = 1;
    public float rangedCooldown = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 12f;
    public float projectileLifetime = 3f;

    [Header("Damaged")]
    public float knockbackDuration = .2f;
    public float knockbackForce = 30;

}
