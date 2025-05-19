using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cliant", menuName = "ScriptableObject/Cliant")]

public class Cliant : ScriptableObject
{
    //script para guardar as informações de cada cliente
    public string debugCliantName;
    [SerializeField]
    public int tipeOfCliant
    {
        get => tipeOfCliant;
        set => tipeOfCliant = value >= 0 && value < 4
            ? value
            : throw new ArgumentOutOfRangeException("Clients/tipeOfCliant/" + debugCliantName);
    }

    public DialogueData Demand;
    //[Tooltip("List Needs to have 4 in Lenth; 0 = Very Satisfied 1 = Satisfied 2 = Unsatisfied 3 = Very Unsatisfied")]
    public DialogueData CorrectAnswer;
    public DialogueData WrongAnswer;
    
    public Dictionary<string, DialogueData> ay;

    public string[] aceptedBeverages;
    public void InitiateCliant() //Selects the kind of Cliant
    {
        switch (tipeOfCliant)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

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
    IEnumerator CliantPatience(float TimeBeforeReturn, int multyplier)
    {
        if (multyplier <= 0)
        {
            yield return new WaitForSeconds(TimeBeforeReturn);
        }
        else
        {
            for (int i = 0; i <= multyplier; i++) // this for can be used for the display of timer
            {
                yield return new WaitForSeconds(TimeBeforeReturn);
            }
        }
    }
}
