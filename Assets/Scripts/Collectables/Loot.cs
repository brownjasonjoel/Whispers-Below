using UnityEngine;
using TMPro;
using System.Collections;

public class Loot : MonoBehaviour
{
    private Player player;
    [SerializeField] private CollectableSO collectableSO;
    [SerializeField] private SpriteRenderer sr;

    public Animator anim;
    public TMP_Text itemMessage;

    [SerializeField] private bool canBeCollected;
    [SerializeField] private float collectDelay;

    public void Initalize(CollectableSO collectableSO)
    { 
         this.collectableSO = collectableSO;
        sr.sprite = collectableSO.itemSprite;

        StartCoroutine(EnableCollection());
    }

    private IEnumerator EnableCollection()
    {
        yield return new WaitForSeconds(collectDelay);

        canBeCollected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();

        if (player == null || !canBeCollected)
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
