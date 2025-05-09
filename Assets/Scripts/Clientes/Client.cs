using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cliant", menuName = "ScriptableObject/CliantDialogueDataHolder")]

public class Cliant : ScriptableObject
{
    //script para guardar as informações de cada cliente
    
    public DialogueData Demand;
    [Tooltip("List Needs to have 4 in Lenth; 0 = Very Satisfied 1 = Satisfied 2 = Unsatisfied 3 = Very Unsatisfied")]
    public DialogueData[] Answers;
}
