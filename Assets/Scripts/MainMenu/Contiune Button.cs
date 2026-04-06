using UnityEngine;
using UnityEngine.SceneManagement;

public class ContiuneButton : MonoBehaviour
{
    public string sceneToLoad;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
