using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{

    // ============================================
    // || Esse script fica no MANAGER da cena    ||
    // ============================================

    Camera mainCamera;

    // Constante pra manter objetos ou instancias de prefabs na mesma coordenada Z (profundidade) dos outros objetos
    const int Z_ABSOLUTE_SCENE_POS = 0;

    // Variaveis para o Input System
    PlayerInput playerInput;
    InputAction touchAction;
    InputAction positionAction;

    // WaitForFixedUpdate fixo para as corotinas nao precisarem criar novas instancias
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    // Posi��o na tela para que objetos movidos acompanhem o dedo do jogador
    public Vector3 cursorPos;



    // Definindo variaveis
    private void Awake()
    {
        mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();

        // ====================================================================================================================
        // Input System: as InputActions aqui usam o NOME DA A��O EM *Assets\InputSystem_Actions.inputactions* COMO REFER�NCIA,
        //               manter isso em mente caso alguem mude um nome posteriormente

        touchAction = playerInput.actions["TouchPress"];       // A��o do toque
        positionAction = playerInput.actions["TouchPosition"]; // posi��o do dedo na tela

        // ====================================================================================================================
    }

    // Ativando e desativando mapas de a��es do InputActions
    private void OnEnable()
    {
        touchAction.Enable();
        touchAction.performed += touchPressed; // Inscreve o metodo ao evento touchAction.performed (quando o jogador toca na tela)
    }
    private void OnDisable()
    {
        touchAction.performed -= touchPressed; // Desinscreve quando o script � desativado
        touchAction.Disable();
    }

    // Metodo pro cursor (cursorPos) acompanhar onde o jogador encosta ou ta encostando na tela
    private void UpdateCursorPosition()
    {
        cursorPos = mainCamera.ScreenToWorldPoint(positionAction.ReadValue<Vector2>());
        cursorPos.z = Z_ABSOLUTE_SCENE_POS;
    }


    // Metodo chamado quando o jogo recebe o input de toque na tela
    private void touchPressed(InputAction.CallbackContext context)
    {
        UpdateCursorPosition();
        RaycastHit2D hit = Physics2D.Raycast(cursorPos, Vector2.zero); // Raycast pra detectar objetos
        if (hit.collider != null)
        {
            SelectParser(hit);
        }
    }

    // Metodo pra determinar que objeto foi detectado primeiro pelo raycast
    private void SelectParser(RaycastHit2D hit)
    {
        if (hit.collider.GetComponent<Ingredient>())
        {               // Para Ingredientes
            hit.collider.GetComponent<Ingredient>().OnClicked();
        }
        else if (hit.collider.CompareTag("Product"))
        {             // Para o produto final (Caf�)
            if (hit.transform.GetComponent<FinalProductProcessing>().occupied == false)
            {
                StartCoroutine(DragProduct(hit.transform.gameObject));
            }
        }
    }

    // Corrotina pra arrastar ingredientes pela tela
    public IEnumerator DragIngredient(GameObject obj)
    {
        while (touchAction.ReadValue<float>() != 0)
        {
            UpdateCursorPosition();
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
        if (touchAction.ReadValue<float>() == 0)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.CompareTag("Product"))
                {
                    hit.transform.GetComponent<FinalProductProcessing>().OnDropIngredient(obj.GetComponent<IngredientCarrier>());
                }
            }
            Destroy(obj);
        }
    }

    // Corrotina pra arrastar o produto at� alguma maquina que altere o produto
    public IEnumerator DragProduct(GameObject obj)
    {
        while (touchAction.ReadValue<float>() != 0)
        {
            UpdateCursorPosition();
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
        if (touchAction.ReadValue<float>() == 0)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.CompareTag("Process"))
                {
                    hit.transform.GetComponent<CoffeeProcess>().OnDropProduct(obj.GetComponent<FinalProductProcessing>());
                    obj.transform.position = hit.transform.position;
                }
            }
        }
    }

}
