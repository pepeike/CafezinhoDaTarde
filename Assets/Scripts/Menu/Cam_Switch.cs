using UnityEngine;

public class Cam_Switch : MonoBehaviour
{
    [SerializeField] public Transform cam01;
    [SerializeField] public Transform cam02;
    [SerializeField] public GameObject ScenePoint;
    //[SerializeField] public GameObject Stand;

    private bool LockCamSwitch = true; // <= True Not Locked / False Locked :RLH107

    public void LockUnLock(bool a) { LockCamSwitch = a; } // <= Change Lock bool :RLH107
    //public void ForceSwitchKitchen(){ ScenePoint.transform.position = cam01.transform.position; Stand.SetActive(false); } // <= Use this only if it has to change :RLH107
    //public void ForceSwitchVitrine() { ScenePoint.transform.position = cam01.transform.position; Stand.SetActive(false); } // <= Use this only if it has to change :RLH107
    public void SwitchCamKitchen()
    {
        if (LockCamSwitch) // <= Locks the CamSwitch :RLH107
        {
            ScenePoint.transform.position = cam01.transform.position;
            //Stand.SetActive(false);
        }
    }

    public void SwitchCamVitrine()
    {
        if (LockCamSwitch) // <= Locks the CamSwitch :RLH107
        {
            ScenePoint.transform.position = cam02.transform.position;
            //Stand.SetActive(true);
        }
    }
}
