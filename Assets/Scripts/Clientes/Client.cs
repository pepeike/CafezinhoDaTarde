using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Cliant", menuName = "ScriptableObject/Cliant")]
public class Cliant : ScriptableObject
{
    //script para guardar as informações de cada cliente
    [HideInInspector] public string debugCliantName;    [HideInInspector] public int tipeOfCliants;
    public DialogueData Demand;     public DialogueData CorrectAnswer;      public DialogueData WrongAnswer;
    public string[] aceptedBeverages;
    public bool hasPatience;    public int patience;    public int pMultyplyer;
    /*
    private int TOC
    {
        get => TOC;
        set => TOC = value >= 0 && value < 2
            ? value
            : throw new ArgumentOutOfRangeException("Clients/tipeOfCliant/" + debugCliantName);
    }
    public void InitiateCliant() //Selects the kind of Cliant (CurrentLy Unused)
    {
        TOC = tipeOfCliants;
        switch (TOC)
        {
            case 0:

                break;
            case 1:
                break;
        }
    }
    */
    public DialogueData AnalyseBeverege(string Beverege)
    {
        bool isThere = false;
        foreach (string name in aceptedBeverages) 
        {
            if(Beverege == name)
            {
                isThere = true;
            }
        }
        if(isThere == true)
        {
            return CorrectAnswer;
        }
        else
        {
            return WrongAnswer;
        }
    }

}
