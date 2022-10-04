using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SaveProgress.LastLoadScene = 1;
            SceneManager.LoadScene(1);
        }

        else
        {
            SaveProgress.LastLoadScene = currentSceneIndex + 1;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }


    }
}
