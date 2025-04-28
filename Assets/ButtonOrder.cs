using UnityEngine;

public class ButtonOrder : MonoBehaviour
{
    public Animator button2animator;
    public Animator button3animator;
   private void Button1done()
    {
        button2animator.SetTrigger("Slide2");
    }

    private void Button2done()
    {
        button3animator.SetTrigger("Slide3");
    }
}
