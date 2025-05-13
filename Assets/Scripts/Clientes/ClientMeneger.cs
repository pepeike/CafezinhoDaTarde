using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public List<Cliant> cliants;    // Lista de Clientes
    private Cliant currentCliant;   // Separates Current Cliant
    private int intCurrentCliant;   // Position of current Cliant in List
    private bool questionOrAnswer; // Flip Flop in between Question And Answer // Question is /*True*/, Answer is /*false*/
    public FinalProductProcessing finalProduct; // Used to Reset FinalProduct
    public DialogueSystem dialogueSystem;

    private void Start()
    {
        cliants = new List<Cliant>();
        intCurrentCliant = 0;
        // Before 
                          //<= Use this Space To Populate List<Cliant>
        // Cliants 
        currentCliant = cliants[0];
        WriteQuestionOrAnswer();//Remove Once to activat
    }

    private void FixedUpdate()
    {
        if(dialogueSystem.isWriting == false)
        {
            if (DelegateCallUnLockInteractions != null)
            {
                DelegateCallUnLockInteractions();
            }
        }
    }

    public void DeliverCoffee() //Button
    {
        if(questionOrAnswer == false)
        {
            //////////////////////////////////////  // <= Add the Get Ingredents
        }
    }

    public void WriteQuestionOrAnswer() //Cliant
    {
        if (questionOrAnswer == false)
        {
            questionOrAnswer = true;
            dialogueSystem.dialogueData = currentCliant.Demand;
        }
        if (questionOrAnswer == true)
        {
            questionOrAnswer = false;
            dialogueSystem.dialogueData = currentCliant.Answers;
        }
        dialogueSystem.Wting();
        if(DelegateCallLockInteractions != null)
        {
            DelegateCallLockInteractions();
        }
    }

    public delegate void LockInteraction();
    LockInteraction DelegateCallLockInteractions;
    public delegate void UnLockInteraction();
    UnLockInteraction DelegateCallUnLockInteractions;

    // Doce+ Amargo- // Energetico+ Relachante-
    private void AnalyseDrink(int Gosto, int Efeito) { }    // <= use this To analyse What Drink is the correct One (if necessery)


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
    }
}
