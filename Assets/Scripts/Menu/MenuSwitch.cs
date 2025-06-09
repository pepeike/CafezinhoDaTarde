using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MenuSwitch : MonoBehaviour
{
    [System.Serializable]
    public class DayStatus
    {
        public bool completed;
        public string levelName;
        public Image lockIcon;
    }

    [Header("Configuração de Paineis")]
    [SerializeField] private GameObject levelSet;
    [SerializeField] private GameObject optionsSet;
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject shoppingSet;
    [Space]

    [Header("Configuração de dias")]
    [Tooltip("Completando os dias libera leveis para os jogadores")]
    [SerializeField] private DayStatus[] days;
    [Space]

    [Header("Configuração de Áudio")]
    [SerializeField] private AudioClip panelOpenSound;
    [SerializeField] private AudioClip panelCloseSound;
    [SerializeField][Range(0, 1)] private float volume = 0.7f;

    private AudioSource audioSource;
    /*
    public SceneData sceneData;
    public string levelName;
    */
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateLockIcons();
    }

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        PlaySound(panelOpenSound);
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
        PlaySound(panelCloseSound);
    }

    public void LoadLevel(string level)
    {
        foreach (var day in days)
        {
            if (day.completed && day.levelName == level)
            {
                
                SceneManager.LoadScene(level);

                return;
            }
        }
    }

    public void UpdateLockIcons()
    {
        foreach (var day in days)
        {
            if (day.lockIcon != null)
            {
                day.lockIcon.gameObject.SetActive(!day.completed);
            }
        }
    }

    public void Return()
    {
        HidePanel(levelSet);
        HidePanel(optionsSet);
        HidePanel(creditos);
        HidePanel(shoppingSet);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    // Métodos simplificados para os botões da UI
    public void LevelSet() => ShowPanel(levelSet) ;
    public void OptionsSet() => ShowPanel(optionsSet);
    public void Creditos() => ShowPanel(creditos);
    public void ShoppingSet() => ShowPanel(shoppingSet);
}


