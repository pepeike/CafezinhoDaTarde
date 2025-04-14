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

    private List<string>[] E = new List<string>[4];


    private void Start()
    {
        this.Text = CliantSpeshObject.GetComponent<TMP_Text>();
        cliants = new List<Cliant>();
        cooldown = true;

        E[0] = new List<string>() {"1","2"};
        E[1] = new List<string>() {"3","4"};
        E[2] = new List<string>() {"5","6"};
        E[3] = new List<string>() {"7","8"};

        cliants.Add(new Cliant(A, E)); //cliants.Add(new Cliant(B)); cliants.Add(new Cliant(C));

        CurrentCliant = cliants[0];
        IntCurrentCliant = 0;
        QuestionDialog = 0;

        DebugAnswer(cliants[0].Answers[0], "1");
        DebugAnswer(cliants[0].Answers[1], "2");
        DebugAnswer(cliants[0].Answers[2], "3");
        DebugAnswer(cliants[0].Answers[3], "4");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (cliants.Count > 0)
        {
            //Debug.LogWarning("Colided");
            if (cooldown == true)       // se o cooldown timer esta ativo
            {
                if (col.tag == "Coffie")        // Verifica se o objeto é um café. (Evita o erro de tentar pegar um objeto que não tenha o CoffieInfo)
                {
                    CoffieInfo CoffieInfo = col.gameObject.GetComponent<CoffieInfo>();
                    if (CurrentCliant.ToString() == CoffieInfo.ToString())     // Se o café é o meso que o cliente atual quer.
                    {                                                   // Sim
                    }
                    else
                    {                                                   // Não
                        StartCoroutine(ReturnToDemand(1.5f));
                    }
                }
                else
                {                               // O objeto Não possui a tag "Coffie"
                    //Debug.Log("Not My Coffie");
                    Text.text = "Isso Não É CAFÉ";
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

    private void DebugQuestion()
    {

    }
    private void DebugAnswer(List<string> ListStr, string DebugSection)
    {
        foreach (string I in ListStr)
        {
            Debug.Log(DebugSection + " String = " +I);
        }
    }
}
