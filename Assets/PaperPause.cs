using UnityEngine;
using UnityEngine.UI;

public class PaperPause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject BtnPause;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject dArrow;
    [SerializeField] private GameObject uArrow;
    [SerializeField] private GameObject dialogue;
    [Header("condição de pause")]
    [SerializeField]public static bool  dontPause;

    public Animator Paper;
    public Button pausebutton;


    /*
        public void ActivatePaper()
        {
            Paper.SetBool("On", true);



        }

        public void WithdrawPaper()
        {
            Paper.SetBool("On", false);

        }
    */
    public void SetPause()
    {
        if (!dontPause) 
        {
            pause.SetActive(true);
            BtnPause.SetActive(false);
            dArrow.SetActive(false);
            uArrow.SetActive(false);

        }
        

    }


    public void Reset()
    {
        pause.SetActive(false);
        BtnPause.SetActive(true);
        dArrow.SetActive(true);
        
    }

    public void Setting()
    {
        setting.SetActive(true);
    }
    public void Return()
    {
        setting.SetActive(false);
        
    }
    //chamar esse metodo quando quiser desativar o pause
    public static void DontPause(bool p)
    {
        dontPause = p;
    }
}

