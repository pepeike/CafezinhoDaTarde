using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    [SerializeField]DialogueSystem dialogueSystem;




    void Awake()
    {
        dialogueSystem = FindAnyObjectByType<DialogueSystem>();
    }

   void Update()
    {
        //aplicar para iniciar o dialogo, trocar para inciar ao clicar no personagem
        if (Input.GetKeyDown(KeyCode.A))
        {
            dialogueSystem.Next();
        }
        
    }

}
