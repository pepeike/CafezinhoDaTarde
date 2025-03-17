using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelChanger : MonoBehaviour
{
    public int StartingPanel;
    private int Panel;
    public List<GameObject> PanelList;
   

    //Requires a seperet System for the in game Options Menu

    private void Start()
    {
        foreach (GameObject Panel in PanelList)
        {
            Panel.SetActive(false);
        }
        if (StartingPanel < PanelList.Count - 1 && StartingPanel >= 0)
        {
            PanelList[StartingPanel].SetActive(true);
            Panel = StartingPanel;
        }
        else
        {
            PanelList[0].SetActive(true);
            Panel = 0;
        }
            ChangePanel(0);
    }

    public void ChangePanel(int Panel)
    {
        if (Panel <= PanelList.Count - 1 && Panel >= 0)
        {
            PanelList[this.Panel].SetActive(false);
            PanelList[Panel].SetActive(true);
            this.Panel = Panel;
        }
        else
        {
            PanelList[0].SetActive(true);
            this.Panel = 0;
            Debug.LogWarning("ChangeToNonExistantPanel " + Panel);
        }
    }
    public void ChangeLevel(string NextLevel) { /*SceneManager.LoadScene(NextLevel);*/ Debug.Log("LoadScene ."+ NextLevel); }
}
