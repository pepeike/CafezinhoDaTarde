using UnityEngine;

public class FinalProduct
{
    public string productName {  get; set; }
    public int ingrA { get; set; }
    public int ingrB { get; set; }
    public int ingrC { get; set; }

}

public class FinalProductProcessing : MonoBehaviour {

    public FinalProduct product;

    private void Awake() {
        product = new FinalProduct();
    }


    public void OnDropIngredient(IngredientCarrier drop) {

        IngredientType dropIngredient = drop.type;

        switch (dropIngredient) {
            case IngredientType.ingredientA:
                product.ingrA++;
                Debug.Log(product.ingrA);
                break;
            case IngredientType.ingredientB:
                product.ingrB++;
                Debug.Log(product.ingrB);
                break;
            case IngredientType.ingredientC:
                product.ingrC++;
                Debug.Log(product.ingrC);
                break;
        }

        UpdateProduct();

    }

    private void UpdateProduct() {
        if (product.ingrA > product.ingrB && product.ingrA > product.ingrC) {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        } else if (product.ingrB > product.ingrA && product.ingrB > product.ingrC) {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        } else if (product.ingrC > product.ingrB && product.ingrC > product.ingrA) {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        }
    }

}

