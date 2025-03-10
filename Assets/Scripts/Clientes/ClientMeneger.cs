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

    private void Start()
    {
        this.Text = CliantSpeshObject.GetComponent<TMP_Text>();
        cliants = new List<Cliant>();
        cooldown = true;

        // <= Crie os clientes aqui. =========================================================

        cliants.Add(new Cliant("QueroCafe�e���", "Latte", "Th", "N������A�hhhhhhhhhhhhhho"));
        cliants.Add(new Cliant("Caff�", "Caputino", "THENKS", "N��o"));

        // ======================================================================================
        Text.text = cliants[0].Demand;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (cliants.Count > 0)
        {
            //Debug.LogWarning("Colided");
            if (cooldown == true)       // se o cooldown timer esta ativo
            {
                if (col.tag == "Coffie")        // Verifica se o objeto � um caf�. (Evita o erro de tentar pegar um objeto que n�o tenha o CoffieInfo)
                {
                    CoffieInfo CoffieInfo = col.gameObject.GetComponent<CoffieInfo>();
                    if (cliants[0].ToString() == CoffieInfo.ToString())     // Se o caf� � o meso que o cliente atual quer.
                    {                                                   // Sim
                        Text.text = cliants[0].Right;
                        ChangeCliant();
                    }
                    else
                    {                                                   // N�o
                        Text.text = cliants[0].Wrong;
                        // <= Add Corrotina
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
    }

    // Muda o cliente atual para o procimo Cliente
    void ChangeCliant()
    {
        Cliant C = cliants[0];
        cliants.Remove(C);
        if (cliants.Count > 0)
        {
            StartCoroutine(ReturnToDemand(1.5f));
        }
        else
        {
            // <= Inserir condi��o de fim de jogo
            Debug.LogWarning("End OF the Line");
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
        Text.text = cliants[0].Demand;
    }

}
