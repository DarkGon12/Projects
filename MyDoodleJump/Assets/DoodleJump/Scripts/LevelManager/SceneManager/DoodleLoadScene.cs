using UnityEngine.SceneManagement;
using UnityEngine;

public class DoodleLoadScene : MonoBehaviour
{
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}