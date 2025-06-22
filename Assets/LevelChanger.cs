using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuProposal");
    }
}
