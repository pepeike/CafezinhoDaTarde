using UnityEngine;
using UnityEngine.UI;

public class PaperPause : MonoBehaviour
{
    public Animator Paper;
    public Button pausebutton;

    public void ActivatePaper()
    {
        Paper.SetBool("On", true);
        
        
       
    }

    public void WithdrawPaper()
    {
        Paper.SetBool("On", false);
       
    }
}

