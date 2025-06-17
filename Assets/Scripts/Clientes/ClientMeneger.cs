using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.
    public DialogueSystem dialogueSystem; public SpawnerController spawnerController;

    public bool Virgilio_Tutorial;  public DialogueData Virgilio_tutorial;
    public bool TwoDrinks;
    public List<Cliant> cliants; /* Lista de Clientes */ private Cliant currentCliant; /* Separates Current Cliant */ private int intCurrentCliant; // Position of current Cliant in List

    public UnityEvent chengeCam; public UnityEvent LockInteraction; public UnityEvent UnLockInteraction;
    
    private bool questionOrAnswer; /* Flip Flop in between Question And Answer // Question is [false], Answer is [true] */  private string Drink;

    private void Start()
    {
        questionOrAnswer = false;
        //cliants = new List<Cliant>();
        intCurrentCliant = 0; //Num Of current Cliant
        currentCliant = cliants[0]; //Current Cliant
        //currentCliant.InitiateCliant(); //start for cliant
        if (Virgilio_Tutorial)
        {
            WriteQuestionOrAnswer();
        }
        else
        {
            StartCoroutine(DelaySpawn(2f));
        }
    }

    //Call The first write question

    public void DeliverCoffee(string Drink) //Button
    {
        if (questionOrAnswer == true)
        {
            this.Drink = Drink;
            chengeCam?.Invoke();
            WriteQuestionOrAnswer();
        }
        //Debug.Log("Drink " + Drink);
    }
    private void WriteQuestionOrAnswer() //Selects question or answer and calls the text writer
    {
        if (Virgilio_Tutorial)
        {
            dialogueSystem.dialogueData = Virgilio_tutorial;
            dialogueSystem.ChangeStateEnable();
            dialogueSystem.CallChangeText();
            return;
        }
        if (questionOrAnswer == false) //Question
        {
            dialogueSystem.dialogueData = currentCliant.Demand;
            dialogueSystem.ChangeStateEnable();
            dialogueSystem.CallChangeText();//Call Writer
        }
        else if (questionOrAnswer == true) //Answer
        {
            dialogueSystem.dialogueData = currentCliant.AnalyseBeverege(Drink);
            dialogueSystem.ChangeStateEnable();
            dialogueSystem.CallChangeText();//Call Writer
        }

        LockInteraction?.Invoke();      //Lock other inputs
    }
    public void InvertQuestionOrAnswer()
    {
        if (Virgilio_Tutorial)
        {
            StartCoroutine(DelaySpawn(2f)); Virgilio_Tutorial = false;
            return;
        }
        if (questionOrAnswer)
        {
            questionOrAnswer = false;
            ChangeCliant();
        }
        else if (questionOrAnswer == false)
        {
            questionOrAnswer = true;
            if (currentCliant.hasPatience == true)
            {
                StartCoroutine(CliantPatience(currentCliant.patience, currentCliant.pMultyplyer));
            }
        }
        UnLockInteraction?.Invoke();
    }


    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    // Muda o cliente atual para o procimo Cliente
    public void ChangeCliant()
    {
        intCurrentCliant++;
        if (cliants.Count > intCurrentCliant)
        {
            currentCliant = cliants[intCurrentCliant];
            questionOrAnswer = false;
            StartCoroutine(DelayDeSpawn(1f));
            StartCoroutine(DelaySpawn(2f));
        }
        else
        {
            intCurrentCliant = intCurrentCliant - 1;
            StartCoroutine(DelayDeSpawn(1f));
            /////////////////////////////////////////////////////////////      <= ADD Win Condition
            Debug.LogWarning("Awaiting Win/End_Condition Code");
        }

    } /* And sets The text select Back to question */

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// < name="CliantPatience"></>
    IEnumerator CliantPatience(float TimeBeforeReturn, int multyplier)
    {
        if (multyplier < 0)
        {
            multyplier = multyplier * (-1);
        }
        //  {////}                                     {////}
        if (multyplier <= 0)
        {
            yield return new WaitForSeconds(TimeBeforeReturn);
            // Acabou a Paciencia
            ChangeCliant();
        }
        else
        {
            int V = 0;
            for (int i = 0; i <= multyplier; i++) // this for can be used for the display of timer
            {
                V++;
                yield return new WaitForSeconds(TimeBeforeReturn);
                Debug.Log("Patience Level = " + V);
                //MudarAnimação
            }
            //Acabou a Paciencia
            ChangeCliant();
        }
    }

    // Temporery Function
    // Necessery for now Dialogue System, Changes the function call into a constant output
   
    IEnumerator DelaySpawn(float a)
    {
        yield return new WaitForSeconds(a);
        spawnerController.SpawnCliant(currentCliant);
        chengeCam?.Invoke();
        LockInteraction?.Invoke();      //Lock other inputs
        yield return new WaitForSeconds(0.5f);
        dialogueSystem.ChangeStateEnable();
        WriteQuestionOrAnswer();
    }
    IEnumerator DelayDeSpawn(float a)
    {
        yield return new WaitForSeconds(a);
        spawnerController.DeSpawnCliant();
    }
}
