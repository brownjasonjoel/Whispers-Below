using UnityEngine;
using TMPro;

public class Loot : MonoBehaviour
{
    private Player player;
    [SerializeField] private CollectableSO collectableSO;

    public Animator anim;
    public TMP_Text itemMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();

        if (player == null)
            return;

        CollectItem();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player = null;
    }

    private void CollectItem()
    {
        itemMessage.text = "Found " + collectableSO.itemName;
        anim.Play("CollectLoot");
        collectableSO.Collect(player);
        Destroy(gameObject, 1);
    }
}
