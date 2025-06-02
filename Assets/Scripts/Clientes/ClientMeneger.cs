using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public GameObject CliantSpeshObject;    // Objeto com o testo para as perguntas e respostas
    public List<Cliant> cliants;    // Lista de Clientes
    private TMP_Text Text;      // Componente de texto
    bool cooldown;      // Status do timer de retorno do a pergunta

    CliantConstructer CC;
    private Cliant CurrentCliant;
    private int IntCurrentCliant;
    private int QuestionDialog, AnswerIn, AnswerDialog;

    // Question is True, Answer is false
    private bool QuestionOrAnswer;

    public FinalProductProcessing finalProduct;
    public GameObject initialProductPrefab;
    private int[] ingredients;
    [SerializeField] Vector3 initCoffeePos;


    private void Start()
    {
        this.Text = CliantSpeshObject.GetComponent<TMP_Text>();
        cliants = new List<Cliant>();
        cooldown = true;

        
        IntCurrentCliant = 0;

        //  <= Start Cliant
        CC = new CliantConstructer();
        cliants = CC.ReturnCliants();

        CurrentCliant = cliants[0];
        ReedQuestionStart();
    }
    // Doce+ Amargo- // Energetico+ Relachante-


    public void DeliverCoffee()
    {
        finalProduct.UpdateProduct();
        ingredients = finalProduct.productProperties;
        ResetCoffee();
        if (QuestionOrAnswer == false)
        {
            ReedAnswerStart();
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
            ReedQuestionStart();
        }
        else
        {
            IntCurrentCliant = IntCurrentCliant - 1;
            // //////////////////////////////////////// <= ADD Win Condition
            Debug.LogError("Awaiting Win/End_Condition Code");
            Text.text = "Dialogo Necessario";
        }
    }

    private void ReedQuestionStart() { QuestionDialog = 0; ReedQuestion(); QuestionOrAnswer = false; }

    public void ReedQuestion()
    {
        //int A = CurrentCliant.DemandArray.Length;
        //int B = QuestionDialog;
        if (QuestionOrAnswer == false)
        {
            if (QuestionDialog <= CurrentCliant.DemandArray.Length - 1)
            {
                Text.text = CurrentCliant.DemandArray[QuestionDialog];
                QuestionDialog++;
            }
        }
    }

    // Doce+ Amargo- // Energetico+ Relachante-
    private void ReedAnswerStart()
    {
        QuestionOrAnswer = true;
        AnswerDialog = 0;
        if (ingredients[0] >= 0 && ingredients[1] >= 0)
        {
            // doce e energetico
            AnswerIn = 0;
        }
        else if(ingredients[0] >= 0 && ingredients[1] < 0)
        {
            // doce e Relachante
            AnswerIn = 1;
        }
        else if (ingredients[0] < 0 && ingredients[1] >= 0)
        {
            // Amargo e energetico
            AnswerIn = 2;
        }
        else
        {
            // Amargo e Relachante
            AnswerIn = 3;
        }
        ReedAnswer();
    }
    public void ReedAnswer()
    {
        if (QuestionOrAnswer == true)
        {
            if (AnswerDialog <= CurrentCliant.Answers[AnswerIn].Count - 1)
            {
                Text.text = CurrentCliant.Answers[AnswerIn][AnswerDialog];
                AnswerDialog++;
            }
            else
            {
                QuestionOrAnswer = false;
                Debug.LogWarning("ChangeTheCliant");
                ChangeCliant();
            }
        }
    }

    public void ResetCoffee()
    {
        Destroy(finalProduct.gameObject);
        finalProduct = Instantiate(initialProductPrefab, initCoffeePos, Quaternion.identity).GetComponent<FinalProductProcessing>();
    }

    /// <summary> Debug
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void DebugAnswer(List<string> ListStr, string DebugSection)
    {
        foreach (string I in ListStr)
        {
            Debug.Log(DebugSection + " String = " + I);
        }
    }
}
