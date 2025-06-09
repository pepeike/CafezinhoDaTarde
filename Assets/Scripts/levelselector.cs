using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public SceneData sceneData;
    public string levelName;

    public void SelectLevel()
    {
        sceneData.selectedLevel = levelName;
        SceneManager.LoadScene("LoadingScene");
    }
}