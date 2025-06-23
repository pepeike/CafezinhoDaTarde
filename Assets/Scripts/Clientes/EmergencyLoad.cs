using UnityEngine;
using UnityEngine.SceneManagement;


public class EmergencyLoad : MonoBehaviour
{
    public void ChangeLevel(string NextLevel)
    {
        SceneManager.LoadScene(NextLevel); Debug.Log("LoadScene ." + NextLevel);
    }
}
