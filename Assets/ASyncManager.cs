using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ASyncManager : MonoBehaviour
{

   
    public void StartLoad(string leveltoLoad)
    {
        StartCoroutine(LoadLevelASync(leveltoLoad));
        Time.timeScale = 1f;
    }
    public void Start()
    {
        string loadScene = "Level "+PlayerPrefs.GetInt("LevelLoadnow"); 
        print(loadScene);
        StartLoad(loadScene);
        
    }

     IEnumerator LoadLevelASync(string leveltoload)
    {

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(leveltoload);
        loadOperation.allowSceneActivation = false;
        while (loadOperation.progress < 0.9f)
        {
            yield return null;
        }

        loadOperation.allowSceneActivation = true;



    }

    


    



}
