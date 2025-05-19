using UnityEngine;

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

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    void Awake()
    {
        typeText = Object.FindFirstObjectByType<TypeTextAnimation>();
        
        dialogueUI = Object.FindFirstObjectByType<DialogueUI>();

        typeText.typeFinished = OnTypeFinishe;
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

    // configurar o bot�o de input de k, para toque;
    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.K))
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
            }

        }

    }
    // configurar o bot�o de input de k, para toque;
    void Typing()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }

    }

    

    
}
