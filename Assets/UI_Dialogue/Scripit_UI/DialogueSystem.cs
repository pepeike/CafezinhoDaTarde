using System.Collections;
using UnityEngine;

using UnityEngine.InputSystem;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}
public class DialogueSystem : MonoBehaviour
{
    public DialogueData dialogueData;//pega o objeto de fala!

    int currentText = 0;
    bool finished = false;

    public CliantManager CM;
    TypeTextAnimation typeText;
    DialogueUI dialogueUI;
    STATE state;
    /// <summary>
    /// ///////////////////////////////////////////////////////////////
    PlayerInput playerInput;
    InputAction touchAction;
    /// </summary>
    void Awake()
    {
        typeText = Object.FindFirstObjectByType<TypeTextAnimation>();
        dialogueUI = Object.FindFirstObjectByType<DialogueUI>();
        typeText.typeFinished = OnTypeFinishe;
        state = STATE.DISABLED;
        /////////////////////////////////////////////////////////////////////////////
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["TouchPress"];
        /////////////////////////////////////////////////////////////////////////////
    }



    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void OnEnable()
    {
        touchAction.Enable();
        touchAction.performed += pressed;
    }
    private void OnDisable()
    {
        touchAction.performed -= pressed;
        touchAction.Disable();
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 



    public void ChangeStateEnable() { state = STATE.WAITING; }
    private void pressed(InputAction.CallbackContext context) { CallChangeText(); }
    public void CallChangeText()
    {
        if(state == STATE.DISABLED)  return;

        switch (state) 
        { 
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }
    }


    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        if (!finished)
        {
            Next();
        }
        else
        {
            dialogueUI.Disable();
            state = STATE.DISABLED;
            currentText = 0;
            finished = false;
            CM.InvertQuestionOrAnswer(); //RLH107
        }
    }
    public void Next()
    {
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name);


        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if (currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTyping();
        state = STATE.TYPING;
    }

    void Typing()
    {
            typeText.Skip();
            state = STATE.WAITING;
    }

    public void DebugString(string a){ Debug.LogWarning(a); } // For emergency ;p :RLH107
}
