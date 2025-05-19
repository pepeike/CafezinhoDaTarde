using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public List<Cliant> cliants;    /* Lista de Clientes */    private Cliant currentCliant;   /* Separates Current Cliant */ private int intCurrentCliant;   // Position of current Cliant in List
    private bool questionOrAnswer; // Flip Flop in between Question And Answer // Question is /*false*/, Answer is /*true*/
    public FinalProductProcessing finalProduct; // Used to Reset FinalProduct
    public DialogueSystem dialogueSystem;

    private void Start()
    {
        questionOrAnswer = false;
        //cliants = new List<Cliant>();
        intCurrentCliant = 0; //Num Of current Cliant
        currentCliant = cliants[0]; //Current Cliant
        currentCliant.InitiateCliant(); //start for cliant
        WriteQuestionOrAnswer();//Remove Once to activat
    }

    private string Drink;
    public void DeliverCoffee(string Drink) //Button
    {
        if(questionOrAnswer == true)
        {
            this.Drink = Drink;
            WriteQuestionOrAnswer();
        }
    }

    private void WriteQuestionOrAnswer() //Selects question or answer and calls the text writer
    {
        if (questionOrAnswer == false) //Question
        {
            dialogueSystem.dialogueData = currentCliant.Demand;
            dialogueSystem.Wting();//Call Writer
        }
        else if (questionOrAnswer == true) //Answer
        {
            /*Redue THIS, ONce IT IS Ready*/
            AnalyseDrink();
            dialogueSystem.Wting();//Call Writer
        }

        if (DelegateCallLockInteractions != null)  //Lock other inputs
        {
            DelegateCallLockInteractions();
        }
    }
    public void InvertQuestionOrAnswer()
    {
        if (questionOrAnswer)
        {
            questionOrAnswer = false;
        }
        else if(questionOrAnswer == false)
        {
            questionOrAnswer = true;
        }
    }

    public delegate void LockInteraction();
    LockInteraction DelegateCallLockInteractions;
    public delegate void UnLockInteraction();
    UnLockInteraction DelegateCallUnLockInteractions;

    public void UnlockOtherInput()
    {
        if(DelegateCallUnLockInteractions != null)
        {
            DelegateCallUnLockInteractions();
        }
    }

    // Doce+ Amargo- // Energetico+ Relachante-
    private void AnalyseDrink()
    {
        //Leve this inside the cliant so there is a bigger change between characters
        dialogueSystem.dialogueData = currentCliant.AnalyseBeverege(Drink);
    }    


    // Muda o cliente atual para o procimo Cliente
    public void ChangeCliant()
    {
        intCurrentCliant++;
        if (cliants.Count > intCurrentCliant)
        {
            currentCliant = cliants[intCurrentCliant];
            currentCliant.InitiateCliant();
            Debug.LogWarning("clientChanged");
        }
        else
        {
            intCurrentCliant = intCurrentCliant - 1;
            currentCliant.InitiateCliant();
            //<= ADD Win Condition
            Debug.LogWarning("Awaiting Win/End_Condition Code");
        }
        questionOrAnswer = false;
    } /* And sets The text select Back to question */




    // Temporery Function
    // Necessery for now Dialogue System, Changes the function call into a constant output
    public bool ButtonState = false;
    public void ChangeText()
    {
        StartCoroutine(DelayState(0.1f));
    }

    IEnumerator DelayState(float a)
    {
        ButtonState = true;
        yield return new WaitForSeconds(a);
        ButtonState = false;
    }
}
