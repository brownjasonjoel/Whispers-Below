using System.Threading;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public Player player;
    public float spellRange;
    public float SpellCoolDown;
    public LayerMask obstacleLayer;

    public float playerRadius = 1.5f;

    public bool canCast => Time.time >= nextCastTime;
    private float nextCastTime;

    public void AnimationFinished()
    {
        player.AnimationFinished();
        CastSpell();

    }

    private void CastSpell()
    {
        Teleport();
    }

    private void Teleport()
    {
        Vector2 direction = new Vector2(player.facingDirection, 0);
        Vector2 targetPosition = (Vector2) player.transform.position + direction * spellRange;

        Collider2D hit = Physics2D.OverlapCircle(targetPosition, playerRadius,obstacleLayer);

        if (hit != null)
        {
            float step = 0.1f;
            Vector2 adjustedPosition = targetPosition;

            while (hit != null && Vector2.Distance(adjustedPosition, player.transform.position) > 0)
            {
                adjustedPosition -= direction * step;
                hit = Physics2D.OverlapCircle(adjustedPosition, playerRadius, obstacleLayer);
            }
            targetPosition = adjustedPosition;
        }

        player.transform.position = targetPosition;
        nextCastTime = Time.time + SpellCoolDown;

    }
}
