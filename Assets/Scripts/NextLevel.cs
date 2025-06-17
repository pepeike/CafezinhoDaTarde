using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{// chamar quando finalizar o level.
    private NextLevel()
    {
        UnlockNewLevel();
        
    }


    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex")) 
        {
            PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    
}
