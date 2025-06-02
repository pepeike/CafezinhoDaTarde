using UnityEngine;
using UnityEngine.InputSystem;

public class CookingManager : MonoBehaviour
{

    public FinalProductProcessing finalProduct;
    public GameObject initialProductPrefab;

    Accelerometer accelerometer;
    Camera mainCam;

    [SerializeField]
    int screenIndex;     // 0 = clientes, 1 = balcão
    [SerializeField]
    Vector3 initCoffeePos;


    public void UpdateCamera() {
        switch (screenIndex) {
            case 0:
                screenIndex = 1;
                //mover camera pro balcão
                break;
            case 1:
                screenIndex = 0;
                //mover camera pros clientes
                break;
        }
    }

    public void ResetCoffee() {
        Destroy(finalProduct.gameObject);
        finalProduct = Instantiate(initialProductPrefab, initCoffeePos, Quaternion.identity).GetComponent<FinalProductProcessing>();
    }

    public void DeliverCoffee() {
        finalProduct.UpdateProduct();
        UpdateCamera();

        //codigo pra entregar o café

        ResetCoffee();

    }


}
