using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public List<Cliant> cliants;    /* Lista de Clientes */    private Cliant currentCliant;   /* Separates Current Cliant */ private int intCurrentCliant;   // Position of current Cliant in List
    private bool questionOrAnswer; // Flip Flop in between Question And Answer // Question is /*True*/, Answer is /*false*/
    public FinalProductProcessing finalProduct; // Used to Reset FinalProduct
    public DialogueSystem dialogueSystem;

    private void Start()
    {
        questionOrAnswer = false;
        //cliants = new List<Cliant>();
        intCurrentCliant = 0;
        // Before 
                          //<= Use this Space To Populate List<Cliant>
        // Cliants 
        currentCliant = cliants[0];
        WriteQuestionOrAnswer();//Remove Once to activat
    }

    public void DeliverCoffee() //Button
    {
        if(questionOrAnswer == false)
        {
            WriteQuestionOrAnswer();
        }
    }

    private void WriteQuestionOrAnswer() //Selects question or answer and calls the text writer
    {
        if (questionOrAnswer == false)
        {
            questionOrAnswer = true;
            dialogueSystem.dialogueData = currentCliant.Demand;
        }
        if (questionOrAnswer == true)
        {
            dialogueSystem.dialogueData = currentCliant.Answers[0];    /*Redue THIS ONce IT IS Ready*/
        }

        if(DelegateCallLockInteractions != null)    
        {
            DelegateCallLockInteractions();
        } //Lock other inputs
        dialogueSystem.Wting();                 //Call Writer
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
    private void AnalyseDrink(int Gosto, int Efeito) // <= use this To analyse What Drink is the correct One (if necessery)
    {
        //Leve this inside the cliant so there is a bigger change between characters
    }    


    // Muda o cliente atual para o procimo Cliente
    void ChangeCliant()
    {
        intCurrentCliant++;
        if (cliants.Count > intCurrentCliant)
        {
            currentCliant = cliants[intCurrentCliant];
            Debug.LogWarning("clientChanged");
        }
        else
        {
            intCurrentCliant = intCurrentCliant - 1;
                                                                            //<= ADD Win Condition
            Debug.LogWarning("Awaiting Win/End_Condition Code");
        }
        questionOrAnswer = false;
    } /* And sets The text select Back to question */
}
