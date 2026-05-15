
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    [Header("Persistant Objects")]
    public GameObject[] persistantObjects;



    private void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    private void MarkPersistentObjects()
    {
        foreach (GameObject obj in persistantObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistantObjects)
        {
            Destroy(obj);
        }

        Destroy(gameObject);
    }

    //private void OnDestroy()
    //{
    //    if()
    //}

}
