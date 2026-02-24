using System.Threading;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public Player player;
    public SpellSO currentSpell;

    [Header("Spark Vaiables")]
    public GameObject sparkFXPrefab;
    public int damage;
    public float damageRadius = 5f;
    public LayerMask enemyLayer;

    public bool canCast => Time.time >= nextCastTime;
    private float nextCastTime;

    public void AnimationFinished()
    {
        player.AnimationFinished();
        CastSpell();

    }

    private void CastSpell()
    {
        if (!canCast || currentSpell == null)
            return;

        currentSpell.Cast(player);


        nextCastTime = Time.time + currentSpell.coolDown;
    }

   
}
