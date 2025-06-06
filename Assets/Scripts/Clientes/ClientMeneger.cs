using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliantManager : MonoBehaviour
{
    // Cria e Manega os clientes e suas respostas.

    public List<Cliant> cliants; /* Lista de Clientes */ private Cliant currentCliant; /* Separates Current Cliant */ private int intCurrentCliant; // Position of current Cliant in List
    private bool questionOrAnswer; // Flip Flop in between Question And Answer // Question is /*false*/, Answer is /*true*/
    public DialogueSystem dialogueSystem;
    private string Drink;
    private void Start()
    {
        questionOrAnswer = false;
        //cliants = new List<Cliant>();
        intCurrentCliant = 0; //Num Of current Cliant
        currentCliant = cliants[0]; //Current Cliant
        //currentCliant.InitiateCliant(); //start for cliant
        dialogueSystem.ChangeStateEnable();
        WriteQuestionOrAnswer();
    }

    //Call The first write question

    public void DeliverCoffee(string Drink) //Button
    {
        if (questionOrAnswer == true)
        {
            this.Drink = Drink;
            WriteQuestionOrAnswer();
        }
        //Debug.Log("Drink " + Drink);
    }
    private void WriteQuestionOrAnswer() //Selects question or answer and calls the text writer
    {
        if (questionOrAnswer == false) //Question
        {
            dialogueSystem.dialogueData = currentCliant.Demand;
            dialogueSystem.CallChangeText();//Call Writer
        }
        else if (questionOrAnswer == true) //Answer
        {
            /*Redue THIS, ONce IT IS Ready*/
            AnalyseDrink();
            dialogueSystem.CallChangeText();//Call Writer
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
        else if (questionOrAnswer == false)
        {
            questionOrAnswer = true;
            if (currentCliant.hasPatience == true)
            {
                StartCoroutine(CliantPatience(currentCliant.patience, currentCliant.pMultyplyer));
            }
        }
    }
    public delegate void LockInteraction();
    LockInteraction DelegateCallLockInteractions;
    public delegate void UnLockInteraction();
    UnLockInteraction DelegateCallUnLockInteractions;

    public void UnlockOtherInput()
    {
        if (DelegateCallUnLockInteractions != null)
        {
            DelegateCallUnLockInteractions();
        }
    }

    private void AnalyseDrink()
    {
        dialogueSystem.dialogueData = currentCliant.AnalyseBeverege(Drink);
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
            Debug.LogWarning("clientChanged");
            WriteQuestionOrAnswer();
        }
        else
        {
            intCurrentCliant = intCurrentCliant - 1;
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
    [HideInInspector] public bool ButtonState = false;
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
