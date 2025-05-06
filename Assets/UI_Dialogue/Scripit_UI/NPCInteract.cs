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
        foreach (Touch touch in Input.touches) 
        {
            if (touch.phase == TouchPhase.Began) 
            {
                Vector2 worldPoint = Camera.main.WorldToScreenPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

                if(hit.collider != null)
                {
                    Debug.Log("Toque no objeto" + hit.collider.gameObject.name);
                }
            }
        }
        



        //aplicar para iniciar o dialogo, trocar para inciar ao clicar no personagem
        if (Input.GetKeyDown(KeyCode.A))
        {
            dialogueSystem.Next();
        }
        
    }
 

}
