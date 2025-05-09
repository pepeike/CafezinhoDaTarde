using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public List<Cliant> cliants;    // Lista de Clientes
    private Cliant CurrentCliant;   // Separates Current Cliant
    private int IntCurrentCliant;   // Position of current Cliant in List

    private int AnswerIn /*Selects The Cliant Responce*/;


    private bool QuestionOrAnswer; // Flip Flop in between Question And Answer // Question is /*True*/, Answer is /*false*/

    public FinalProductProcessing finalProduct; // Used to Reset FinalProduct
    public GameObject initialProductPrefab;     // Prefab For the Coffie
    private int[] ingredients;                  // Ingredients of the Final Product
    [SerializeField] Vector3 initCoffeePos;     // Psition of the Coffie


    private void Start()
    {
        cliants = new List<Cliant>();           // Generates a new List<Cliant>
        IntCurrentCliant = 0;

        // Before 
                                                //<= Use this Space To Populate List<Cliant>
        // Cliants 
        CurrentCliant = cliants[0];
        ReedQuestion();
    }


    public void DeliverCoffee()
    {
        if(QuestionOrAnswer == false)
        {
            finalProduct.UpdateProduct();
            ingredients = finalProduct.productProperties;
            finalProduct.ResetTasteEffect();
            SelectAnswer();
        }
    }

    // Muda o cliente atual para o procimo Cliente
    void ChangeCliant()
    {
        IntCurrentCliant++;
        if (cliants.Count > IntCurrentCliant)
        {
            CurrentCliant = cliants[IntCurrentCliant];
            Debug.LogWarning("clientChanged");
        }
        else
        {
            IntCurrentCliant = IntCurrentCliant - 1;
                                                                                 //<= ADD Win Condition
            Debug.LogWarning("Awaiting Win/End_Condition Code");
        }
    }

    public void ReedQuestion()
    {
        if (QuestionOrAnswer == false)
        {
            QuestionOrAnswer = true;
            ////////////////////////////////////////// <= Set the ReedFunction
        }
    }

    // Doce+ Amargo- // Energetico+ Relachante-
    private void SelectAnswer()
    {
        QuestionOrAnswer = true;
        //AnswerDialog = 0;
        if (ingredients[0] >= 0 && ingredients[1] >= 0)
        {
            // Doce e Energetico
            AnswerIn = 0;
        }
        else if(ingredients[0] >= 0 && ingredients[1] < 0)
        {
            // Doce e Relachante
            AnswerIn = 1;
        }
        else if (ingredients[0] < 0 && ingredients[1] >= 0)
        {
            // Amargo e Energetico
            AnswerIn = 2;
        }
        else
        {
            // Amargo e Relachante
            AnswerIn = 3;
        }
        //ReedAnswer();
    }
}
