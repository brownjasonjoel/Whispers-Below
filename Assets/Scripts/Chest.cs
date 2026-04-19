using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private List <CollectableSO> lootTable =  new List<CollectableSO>();
    [SerializeField] private GameObject lootPrefab;
    [SerializeField] private float spawnDelay = .2f;
    [SerializeField] private float launchForce;

    private PlayerInput playerInput;
    private bool isOpened;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out var input))
        {
            playerInput = input;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out var input))
        {
            if (input == playerInput)
            {
                playerInput = null;
            }
        }
    }

    private void Update()
    {
        if(isOpened || playerInput == null)
        {
            return;
        }

        if (playerInput.actions["Interact"].WasPressedThisFrame())
        {
            StartCoroutine(OpenChestRoutine());
        }
    }

    private IEnumerator OpenChestRoutine()
    {
        isOpened = true;
        anim.Play("ChestOpen");

        yield return new WaitForSeconds(spawnDelay);

        foreach (CollectableSO loot in lootTable)
        {
            Loot newLoot = Instantiate(lootPrefab, transform.position, Quaternion.identity).GetComponent<Loot>();
            newLoot.Initalize(loot);

            Rigidbody2D rb = newLoot.GetComponent<Rigidbody2D>();

            Vector2 direction = new Vector2(Random.Range(-.5f, .5f), 1).normalized;
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(spawnDelay);
        }
        
    }
}
