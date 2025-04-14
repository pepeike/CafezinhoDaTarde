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

    private Cliant CurrentCliant;
    private int IntCurrentCliant;
    private int QuestionDialog;


    private string[] A = { "A", "B", "C", "D", "E" };
    private string[] B = { "B", "C", "D", "E", "F" };
    private string[] C = { "C", "D", "E", "F", "G" };
    private string[,] w = { { "C", "D", "E", "F", "G" }, { "s", "a", "a", "a", "s" } };




    private List<string> A1 = new List<string> { "asda", "sdf" };




    private void Start()
    {
        this.Text = CliantSpeshObject.GetComponent<TMP_Text>();
        cliants = new List<Cliant>();
        cooldown = true;

        cliants.Add(new Cliant(A, w)); //cliants.Add(new Cliant(B)); cliants.Add(new Cliant(C));

        CurrentCliant = cliants[0];
        IntCurrentCliant = 0;
        QuestionDialog = 0;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (cliants.Count > 0)
        {
            //Debug.LogWarning("Colided");
            if (cooldown == true)       // se o cooldown timer esta ativo
            {
                if (col.tag == "Coffie")        // Verifica se o objeto � um caf�. (Evita o erro de tentar pegar um objeto que n�o tenha o CoffieInfo)
                {
                    CoffieInfo CoffieInfo = col.gameObject.GetComponent<CoffieInfo>();
                    if (CurrentCliant.ToString() == CoffieInfo.ToString())     // Se o caf� � o meso que o cliente atual quer.
                    {                                                   // Sim
                    }
                    else
                    {                                                   // N�o
                        StartCoroutine(ReturnToDemand(1.5f));
                    }
                }
                else
                {                               // O objeto N�o possui a tag "Coffie"
                    //Debug.Log("Not My Coffie");
                    Text.text = "Isso N�o � CAF�";
                    // <= ADD Corrotina
                    StartCoroutine(ReturnToDemand(1.5f));
                }
            }
        }
        else { Debug.LogError("clients.List is empty"); }
        */
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
        }
    }

    private void ChangeQuestionPart()
    {
        //int A = CurrentCliant.DemandArray.Length;
        //int B = QuestionDialog;
        if (QuestionDialog <= CurrentCliant.DemandArray.Length - 1)
        {
            Text.text = CurrentCliant.DemandArray[QuestionDialog];
            QuestionDialog++;
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
}
