using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour {

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

    // Referencia ao CliantMeneger
    [SerializeField] private CliantManager CM;
    // Posição na tela para que objetos movidos acompanhem o dedo do jogador
    public Vector3 cursorPos;



    // Definindo variaveis
    private void Awake() {
        mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();

        // ====================================================================================================================
        // Input System: as InputActions aqui usam o NOME DA AÇÃO EM *Assets\InputSystem_Actions.inputactions* COMO REFERÊNCIA,
        //               manter isso em mente caso alguem mude um nome posteriormente

        touchAction = playerInput.actions["TouchPress"];       // Ação do toque
        positionAction = playerInput.actions["TouchPosition"]; // posição do dedo na tela

        // ====================================================================================================================
    }

    // Ativando e desativando mapas de ações do InputActions
    private void OnEnable() {
        touchAction.Enable();
        touchAction.performed += touchPressed; // Inscreve o metodo ao evento touchAction.performed (quando o jogador toca na tela)
    }
    private void OnDisable() {
        touchAction.performed -= touchPressed; // Desinscreve quando o script é desativado
        touchAction.Disable();
    }

    // Metodo pro cursor (cursorPos) acompanhar onde o jogador encosta ou ta encostando na tela
    private void UpdateCursorPosition() {
        cursorPos = mainCamera.ScreenToWorldPoint(positionAction.ReadValue<Vector2>());
        cursorPos.z = Z_ABSOLUTE_SCENE_POS;
    }


    // Metodo chamado quando o jogo recebe o input de toque na tela
    private void touchPressed(InputAction.CallbackContext context) {
        UpdateCursorPosition();
        RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero); // Raycast pra detectar objetos
        if (hits.Length > 0) {
            SelectParser(hits);
        }
    }

    // Metodo pra determinar que objeto foi detectado primeiro pelo raycast
    private void SelectParser(RaycastHit2D[] hits) {
        foreach (RaycastHit2D hit in hits) {
            if (hit.collider.CompareTag("Product")) {
                if (hits.Any(h => h.collider.CompareTag("Brewer"))) {
                    // Se o produto for clicado e houver um Brewer, arrasta o produto e reseta o copo do Brewer
                    StartCoroutine(DragProduct(hit.transform.gameObject));
                    hits[hits.ToList().FindIndex(h => h.collider.CompareTag("Brewer"))].collider.GetComponent<CoffeeBrewer>().ResetCup();
                    return;
                } else {
                    // Se o produto for clicado mas não houver Brewer, apenas arrasta o produto
                    break;
                }
            }
        }

        if (hits.Length == 1) {
            RaycastHit2D hit = hits[0];
            if (hit.collider.GetComponent<IngredientSpawner>()) {               // Para Ingredientes
                hit.collider.GetComponent<IngredientSpawner>().OnClicked();
                return;
            }

            if (hit.collider.CompareTag("Milk")) {
                //hit.collider.enabled = false; // Desativa o collider do leite para evitar múltiplos toques
                StartCoroutine(DragIngredient(hit.transform.gameObject)); // Para ingredientes líquidos (água, leite, etc.)
                return;
            }

            if (hit.collider.CompareTag("Product")) {             // Para o produto final (Café)
                if (hit.transform.GetComponent<FinalProductProcessing>().occupied == false) {
                    StartCoroutine(DragProduct(hit.transform.gameObject));
                    return;
                }
            }

            if (hit.collider.CompareTag("Grinder")) {
                if (hit.transform.GetComponent<CoffeeGrinder>().currentState == CoffeeGrinder.GrinderState.Finished) {
                    StartCoroutine(DragIngredient(hit.transform.GetComponent<CoffeeGrinder>().SpawnGroundIngred()));
                    return;
                }
            }

            if (hit.collider.CompareTag("Ingredient")) {
                if (hit.transform.GetComponent<IngredientCarrier>().isVisible == true) {
                    StartCoroutine(DragIngredient(hit.transform.gameObject)); // Para ingredientes que podem ser arrastados
                    return;
                }
            }

            if (hit.collider.CompareTag("Brewer")) {
                if (hit.transform.GetComponent<CoffeeBrewer>().currentState == CoffeeBrewer.BrewerState.Idle) {
                    hit.transform.GetComponent<CoffeeBrewer>().OnPress(); // Se o Brewer estiver ocioso, chama o método OnPress
                    return;
                }
            }

        }

        
    }

    // Corrotina pra arrastar ingredientes pela tela
    public IEnumerator DragIngredient(GameObject obj) {
        while (touchAction.ReadValue<float>() != 0) {
            UpdateCursorPosition();
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
        if (touchAction.ReadValue<float>() == 0) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            Debug.Log(hits.Length);
            DragToParser(hits, obj); // Chama o metodo que verifica onde o ingrediente foi largado

        }
    }



    void DragToParser(RaycastHit2D[] hits, GameObject obj) {
        if (hits.Length > 0) {
            
            foreach (RaycastHit2D hit in hits) {

                Debug.Log(hit.transform.name + " - " + hit.transform.tag);

                if (hit.transform.CompareTag("Grinder")) {
                    if (hit.transform.GetComponent<CoffeeGrinder>().currentState == CoffeeGrinder.GrinderState.Idle) {
                        hit.transform.GetComponent<CoffeeGrinder>().StartGrinding(obj.GetComponent<IngredientCarrier>().ingred, obj.GetComponent<IngredientCarrier>());
                        obj.GetComponent<IngredientCarrier>().UpdateSprite(); // Desativa a visibilidade do ingrediente enquanto está sendo processado
                        return;
                    }
                }

                if (hit.transform.CompareTag("Brewer")) {
                    //CoffeeBrewer brewer = hit.transform.GetComponent<CoffeeBrewer>();

                    hit.transform.GetComponent<CoffeeBrewer>().OnDropIngred(obj.GetComponent<IngredientCarrier>().ingred, obj.GetComponent<IngredientCarrier>());
                    if (obj.CompareTag("Milk")) {
                        obj.GetComponent<IngredientCarrier>().ResetPos();
                    }
                }



                if (!hit.transform.CompareTag("Grinder") && !hit.transform.CompareTag("Brewer") && !obj.transform.CompareTag("Milk")) {
                    Destroy(obj);
                }
            }
        } else if (obj.transform.CompareTag("Milk") == true) {

            obj.GetComponent<IngredientCarrier>().ResetPos(); // Reposiciona o leite na posição inicial
            return;

        } else {
            Destroy(obj);
        }
    }

    // Corrotina pra arrastar o produto até alguma maquina que altere o produto
    public IEnumerator DragProduct(GameObject obj) {
        while (touchAction.ReadValue<float>() != 0) {
            UpdateCursorPosition();
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
        if (touchAction.ReadValue<float>() == 0) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            DragProductToParser(obj, hits);
        }
    }

    [SerializeField] private GameObject CoffiePREFAB;
    private void DragProductToParser(GameObject obj, RaycastHit2D[] hits) {
        foreach (RaycastHit2D hit in hits) {
            if (hit.transform.CompareTag("Brewer")) {
                hit.transform.GetComponent<CoffeeBrewer>().OnDropCup(obj.GetComponent<FinalProductProcessing>());
                obj.transform.position = hit.transform.position;
            } else if (hit.transform.CompareTag("Deliverer")) {
                obj.GetComponent<FinalProductProcessing>().UpdateProduct();
                string Drink = obj.GetComponent<FinalProductProcessing>().productName;
                CM.DeliverCoffee(Drink);
                Destroy(obj);
                Instantiate(CoffiePREFAB, new Vector3(-22.6f, -17.01f, 0f), Quaternion.identity);
            }
        }
    }

}
