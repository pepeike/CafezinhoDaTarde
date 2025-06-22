using UnityEngine;

public class Autodeactivate : MonoBehaviour
{
    public Animator Anim;


    private void Start()
    {
        Invoke("ShowAnimation", 0f);
    }


    private void ShowAnimation()
    {
        Anim.SetTrigger("OnStartScene");
        
    }
    private void Deactivate()
    {
        
        this.gameObject.SetActive(false);
    }
}
