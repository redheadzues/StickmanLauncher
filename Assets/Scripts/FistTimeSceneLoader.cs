using UnityEngine;
using UnityEngine.SceneManagement;

public class FistTimeSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(SaveProgress.LastLoadScene);
    }
}
