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
    private bool QuestionOrAnswer;

    public FinalProductProcessing finalProduct;
    public GameObject initialProductPrefab;
    private int[] ingredients;
    [SerializeField] Vector3 initCoffeePos;

    private string[] A = { "A", "B", "C", "D", "E" };
    private List<string>[] E = new List<string>[4];


    private void Start()
    {
        this.Text = CliantSpeshObject.GetComponent<TMP_Text>();
        cliants = new List<Cliant>();
        cooldown = true;

        //E[0] = new List<string>() { "1", "2", "asda" };
        //E[1] = new List<string>() { "3", "4", "Vaca", "s" };
        //E[2] = new List<string>() { "5", "6" };
        //E[3] = new List<string>() { "7" };

        //cliants.Add(new Cliant(A, E)); //cliants.Add(new Cliant(B)); cliants.Add(new Cliant(C));

        
        IntCurrentCliant = 0;

        //DebugAnswer(cliants[0].Answers[0], "1");
        //DebugAnswer(cliants[0].Answers[1], "2");
        //DebugAnswer(cliants[0].Answers[2], "3");
        //DebugAnswer(cliants[0].Answers[3], "4");

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
        ReedAnswerStart();
    }

    // Muda o cliente atual para o procimo Cliente
    void ChangeCliant()
    {
        IntCurrentCliant++;
        if (cliants.Count > IntCurrentCliant)
        {
            CurrentCliant = cliants[IntCurrentCliant];
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
        }
    }

    // Timer de Cooldown depois de um objeto ter sido entregue e Retorna a Pergunta do cliente atual
    private IEnumerator ReturnToDemand(float Seconds)
    {
        cooldown = false;
        float time = Seconds;
        while (time >= 0)
        {
            time = time - Time.deltaTime;
            yield return new WaitForFixedUpdate();
            //Debug.Log("seconds " + time);
        }
        yield return null;
        cooldown = true;
    }

    public void ResetCoffee()
    {
        Destroy(finalProduct.gameObject);
        finalProduct = Instantiate(initialProductPrefab, initCoffeePos, Quaternion.identity).GetComponent<FinalProductProcessing>();
    }

    /// <summary> Debug
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void DebugQuestion()
    {

    }
    private void DebugAnswer(List<string> ListStr, string DebugSection)
    {
        foreach (string I in ListStr)
        {
            Debug.Log(DebugSection + " String = " + I);
        }
    }
}
