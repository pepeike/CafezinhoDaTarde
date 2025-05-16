using System;
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
    public DialogueData[] Answers;

    public void InitiateCliant()
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
}
