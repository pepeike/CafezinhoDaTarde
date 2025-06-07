using UnityEngine;
using UnityEngine.UI;

public class PaperPause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject BtnPause;
    [SerializeField] private GameObject setting;

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
        pause.SetActive(true);
        BtnPause.SetActive(false);

    }

    public void Reset()
    {
        pause.SetActive(false);
        BtnPause.SetActive(true);
    }

    public void Setting()
    {
        setting.SetActive(true);
    }
    public void Return()
    {
        setting.SetActive(false);
    }
}

