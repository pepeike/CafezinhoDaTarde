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
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    const int Z_Absolut_SC_POS = 0;
    PlayerInput playerInput; InputAction touchAction;
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DialogueData dialogueData;//pega o objeto de fala!

    int currentText = 0;
    bool finished = false;
    bool Stopper = false;

    public CliantManager CM;
    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["TouchPress"];

        typeText = Object.FindFirstObjectByType<TypeTextAnimation>();
        dialogueUI = Object.FindFirstObjectByType<DialogueUI>();
        typeText.typeFinished = OnTypeFinishe;
    }

    private void OnEnable()
    {
        touchAction.Enable();
        touchAction.performed += tochPressed;
    }
    private void OnDisable()
    {
        touchAction.performed -= tochPressed;
        touchAction.Disable();
    }
    private void tochPressed(InputAction.CallbackContext context) { StartCoroutine(DelayState(0.1f)); }
    private bool ELongateState = false;
    private IEnumerator DelayState(float a)
    {
        ELongateState = true;
        yield return new WaitForSeconds(a);
        ELongateState = false;
        Stopper = false;
    }




    void Start()
    {
       state = STATE.DISABLED;
    }
    void Update()
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

    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }

    // configurar o botão de input de k, para toque;
    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.K) || ELongateState == true && Stopper == false)
        {
            Stopper = true;
            Wting();
        }
    }
    public void Wting() //RLH107
    {
        // Not RLH107
        // {
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
        // }
    }
    // configurar o botão de input de k, para toque;
    void Typing()
    {
        if (Input.GetKeyDown(KeyCode.K) || ELongateState == true && Stopper == false)
        {
            Stopper = true;
            typeText.Skip();
            state = STATE.WAITING;
        }

    }
}
