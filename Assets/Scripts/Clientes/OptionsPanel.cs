using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    public GameObject OptionPanel;
    private bool PanelState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(OptionPanel == null) { Debug.Log("Options Panel Missing"); }
        else { OptionPanel.SetActive(false); PanelState = false; }
    }

    public void ChangePanelState()
    {
        if(PanelState == false) { OptionPanel.SetActive(true); PanelState = true; }
        else if(PanelState == true) { OptionPanel.SetActive(false); PanelState = false; }
    }
}
