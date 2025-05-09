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

        typeText.typeFinished = OnTypeFinishe;                          // O Escritor terminou
    }
    void Start()
    {
       state = STATE.DISABLED;
    }

    void Update()
    {
        if(state == STATE.DISABLED)
            return;



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
                                                                        // O Codigo Empilha as letras
        dialogueUI.SetName(dialogueData.talkScript[currentText].name);      //Nome do Personagem
                

        typeText.fullText = dialogueData.talkScript[currentText++].text;    //escreve o Dialogo

        if (currentText == dialogueData.talkScript.Count) finished = true;      //Verifica se o Escritor Terminou de escrever

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
    // configurar o botão de input de k, para toque;
    void Typing()                                   // Para Dar Skip no Escritor
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
