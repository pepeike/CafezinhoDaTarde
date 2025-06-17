using UnityEngine;

[CreateAssetMenu(fileName = "Cliant", menuName = "ScriptableObject/Cliant")]
public class Cliant : ScriptableObject
{
    //script para guardar as informações de cada cliente
    [HideInInspector] public string debugCliantName;
    public DialogueData Demand; public DialogueData CorrectAnswer; public DialogueData WrongAnswer;
    public string[] aceptedBeverages;
    public GameObject CliantPrefab;

    public int pMultyplyer { get; private set; } = 3;
    public bool hasPatience;
    [Tooltip("O Tempo entre os estagions de paciencia; Multiplique o valos colocado por x3 para saber o valor Real")] public int patience;

    public DialogueData AnalyseBeverege(string Beverege)
    {
        bool isThere = false;
        foreach (string name in aceptedBeverages)
        {
            if (Beverege == name)
            {
                isThere = true;
            }
        }
        if (isThere == true)
        {
            return CorrectAnswer;
        }
        else
        {
            return WrongAnswer;
        }
    }

}
