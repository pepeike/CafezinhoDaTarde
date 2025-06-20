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

    [Header("Transition")]
    [SerializeField] private GameObject openouttranstion;
    [SerializeField] public int storedlevelint;

    private AudioSource audioSource;

    public Button[] buttons;
    public GameObject levelButtons;

    void Awake()
    {
        storedlevelint = 1;
        ButtonsToArray();
        audioSource = GetComponent<AudioSource>();
        UpdateLockIcons();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].interactable = false;
        }
        for (int i = 0;i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
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


    public void LoadLevel(int level)
    {
        
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("LevelLoadnow", storedlevelint);

    }
    public void LsoadLevel(string level)
    {
        foreach (var day in days)
        {
            if (day.completed && day.levelName == level)
            {
                //ativa depois que junta os leveis
                //string lavelName = "Level " + level;
                //SceneManager.LoadScene(lavelName);
                SceneManager.LoadScene("Loading");
                PlayerPrefs.SetString("LevelLoadnow", level);
               
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

    void ButtonsToArray()
    {
        int ChildCount = levelButtons.transform.childCount;
        buttons = new Button[ChildCount];
        for (int i = 0; i < ChildCount; i++) 
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    public void TransitionBeforeLevelSwitch(int leveltoload)
    {
        openouttranstion.SetActive(true);
        storedlevelint = 1;
        
    }

    // Métodos simplificados para os botões da UI
    public void LevelSet() => ShowPanel(levelSet) ;
    public void OptionsSet() => ShowPanel(optionsSet);
    public void Creditos() => ShowPanel(creditos);
    public void ShoppingSet() => ShowPanel(shoppingSet);
}