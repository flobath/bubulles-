using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string cafeSceneSceneName = "CafeScene";

    public void switchScene()
    {
        SceneManager.LoadScene(cafeSceneSceneName);
    }
}
