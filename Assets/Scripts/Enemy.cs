using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator anim;
    public Health health;

    [Header("Death Fx")]
    [SerializeField] private GameObject[] deathParts;
    [SerializeField] private float spawnForce = 5;
    [SerializeField] private float torque = 5;
    [SerializeField] private float lifeTime = 2;

    private void OnEnable()
    {
        health.OnDamaged += HandleDamage;
        health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        health.OnDamaged -= HandleDamage;
        health.OnDeath -= HandleDeath;
    }

    void HandleDamage()
    {
        anim.SetTrigger("isDamaged");
    }

    void HandleDeath()
    {
        foreach (GameObject prefab in deathParts)
        { 
            Quaternion rotaion = Quaternion.Euler(0,0,Random.Range(0.5f, 1)).normalized;
           GameObject part =  Instantiate(prefab, transform.position, rotaion);

            Rigidbody2D rb = part.GetComponent<Rigidbody2D>();

            Vector2 radomDirection = new Vector2(Random.Range(-1, 1), Random.Range(0.5f, 1)).normalized;
            rb.linearVelocity = radomDirection * spawnForce;
            rb.AddTorque(Random.Range(-torque, torque),ForceMode2D.Impulse);

            Destroy(part, lifeTime);
        }
        Destroy(gameObject);
    }
}
