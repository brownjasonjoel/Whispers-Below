using UnityEngine;

public class JumpFail : MonoBehaviour
{
    public Vector2 resawnPoint;
    public Player player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == player.playerCollider)
        {
            player.transform.position = resawnPoint;
        }
    }
}
