using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private string endSceneName = "Ending";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadEnding());
        }
    }

    private IEnumerator LoadEnding()
    {
        // Destroy persistent GameManager
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }

        // Wait one frame so destruction finishes
        yield return null;

        // Load ending scene
        SceneManager.LoadScene(endSceneName);
    }
}