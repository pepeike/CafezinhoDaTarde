using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ASyncManager : MonoBehaviour
{
    public void StartLoad(string leveltoLoad)
    {

    }
    public void Start()
    {
        StartLoad("LevelProposal");
        StartCoroutine(LoadLevelASync("LevelProposal"));
    }

     IEnumerator LoadLevelASync(string leveltoload)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("LevelProposal");
            if(loadOperation.isDone == true)
        {
            SceneManager.LoadScene("LevelProposal");
            yield return null;
        }
        
    }

    


    



}
