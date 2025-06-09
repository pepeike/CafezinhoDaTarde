using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class ASyncManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SceneData sceneData;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider progressBar;
    [SerializeField] private float minLoadTime = 1f;

    private void Start()
    {
        StartCoroutine(LoadLevelAsync(sceneData.selectedLevel));
    }

    private IEnumerator LoadLevelAsync(string levelToLoad)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        operation.allowSceneActivation = false;

        float timer = 0f;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;

            if (timer >= minLoadTime && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    /*

        public void StartLoad(string leveltoLoad)
        {
            StartCoroutine(LoadLevelASync(leveltoLoad));
            Time.timeScale = 1f;
        }
        public void Start()
        {
            StartLoad("Level_1");

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
        */
}

