using UnityEngine;

public class Autodeactivate : MonoBehaviour
{
   private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
