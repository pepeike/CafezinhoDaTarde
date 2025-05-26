using UnityEngine;

public class Cam_Switch : MonoBehaviour
{
    [SerializeField] public Transform cam01;
    [SerializeField] public Transform cam02;
    [SerializeField] public GameObject ScenePoint;
    [SerializeField] public GameObject Stand;

    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void SwitchCamKitchen()
    {
        ScenePoint.transform.position = cam01.transform.position;
        Stand.SetActive(false);


    }

    public void SwitchCamVitrine()
    {
        ScenePoint.transform.position = cam02.transform.position;
        Stand.SetActive(true);
    }
}
