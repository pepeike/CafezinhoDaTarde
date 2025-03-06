using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour {

    Camera mainCamera;
    [SerializeField]
    GameObject player;
    PlayerInput playerInput;

    InputAction touchAction;
    InputAction positionAction;
    [SerializeField]
    GameObject ingredient;
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public Vector3 cursorPos;

    


    private void Awake() {
        //player = gameObject;
        mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["TouchPress"];
        positionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable() {
        touchAction.Enable();
        
        touchAction.performed += touchPressed;
    }

    private void OnDisable() {
        touchAction.performed -= touchPressed;
        touchAction.Disable();
    }

    

    private void touchPressed(InputAction.CallbackContext context) {
        cursorPos = mainCamera.ScreenToWorldPoint(positionAction.ReadValue<Vector2>());
        cursorPos.z = player.transform.position.z;
        RaycastHit2D hit = Physics2D.Raycast(cursorPos, Vector2.zero);
        if (hit.collider != null) {
            SelectParser(hit);
        }
    }

    private void SelectParser(RaycastHit2D hit) {
        if (hit.collider.GetComponent<Ingredient>()) {
            //GameObject inst = Instantiate(hit.collider.gameObject, cursorPos, Quaternion.identity);
            //inst.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 2;
            //StartCoroutine(DragIngredient(inst));
            hit.collider.GetComponent<Ingredient>().OnClicked();
        } else if (hit.collider.CompareTag("Product")) {
            StartCoroutine(DragProduct(hit.transform.gameObject));
        }
    }

    public IEnumerator DragIngredient(GameObject obj) {
        while (touchAction.ReadValue<float>() != 0) {
            cursorPos = mainCamera.ScreenToWorldPoint(positionAction.ReadValue<Vector2>());
            cursorPos.z = player.transform.position.z;
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
        if (touchAction.ReadValue<float>() == 0) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            foreach (RaycastHit2D hit in hits) {
                if (hit.transform.CompareTag("Product")) {
                    hit.transform.GetComponent<FinalProductProcessing>().OnDropIngredient(obj.GetComponent<IngredientCarrier>());
                }
            }
            Destroy(obj);
        }
    }

    public IEnumerator DragProduct(GameObject obj) {
        while (touchAction.ReadValue < float>() != 0) {
            cursorPos = mainCamera.ScreenToWorldPoint(positionAction.ReadValue<Vector2>());
            cursorPos.z = player.transform.position.z;
            obj.transform.position = cursorPos;
            yield return waitForFixedUpdate;
        }
    }

}
