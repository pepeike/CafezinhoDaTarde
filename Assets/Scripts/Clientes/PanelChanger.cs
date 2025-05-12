using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PanelChanger : MonoBehaviour
{
    public List<int> StartingPanel;     //List For The Panels in PanelList That Are Visible at the start of the scene
    public List<GameObject> PanelList;  //List of all Panels (Active and Inactive)
    public GameObject openoutTransition;
    public Animator pausescreenReturn;

    private void Start()
    {
        foreach (GameObject Panel in PanelList)  //Sets all panels False
        {
            Panel.SetActive(false);
        }
        foreach (int SP in StartingPanel)  //Sets all Panels, Determined in StartingPanel List, as true
        {
            if (SP < PanelList.Count - 1 && SP >= 0)
            {
                PanelList[SP].SetActive(true);
            }
            else { Debug.LogError("PanelStartOutsideOfRange"); }// <= Error if There is a Panel Set to be true that does not exist
        }
    }

    public void SetPanelTrue(int Panel)// <= Sets panel true (Button)
    {
        PanelList[Panel].SetActive(true);
        
    }

    public void SetPanelFalse(int Panel)// <= Sets panel false (Button)
    {

        PanelList[Panel].SetActive(false);
    }

    public void Transition()
    {
        openoutTransition.SetActive(true);
    }

    

    
    public void ChangeLevel(string NextLevel) { SceneManager.LoadScene(NextLevel); /* Debug.Log("LoadScene ."+ NextLevel); */ }
}
