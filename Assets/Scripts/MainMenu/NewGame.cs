using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public string sceneToLoad;
    
    public void loadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
