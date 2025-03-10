using UnityEngine;


public class FinalProductProcessing : MonoBehaviour {

    public string productName; // Nome do produto

    // Ingredientes colocados no produto, determinam o nome do produto
    int ingredientA;
    int ingredientB;
    int ingredientC;

    // Processos feitos no produto, tambem determinam o nome (até o momento inutilizados)
    public bool processA = false;
    public bool processB = false;
    public bool processC = false;

    // Metodo chamado quando um ingrediente é adicionado
    public void OnDropIngredient(IngredientCarrier drop) {

        IngredientType dropIngredient = drop.type;

        switch (dropIngredient) {                           // Switch pra determinar qual ingrediente deve ser adicionado
            case IngredientType.ingredientA:
                ingredientA++;
                
                Debug.Log($"IngredientA: {ingredientA} " +
                    $"\nIngredientB: {ingredientB} " +
                    $"\nIngredientC: {ingredientC}");

                break;

            case IngredientType.ingredientB:
                ingredientB++;

                Debug.Log($"IngredientA: {ingredientA} " +
                    $"\nIngredientB: {ingredientB} " +
                    $"\nIngredientC: {ingredientC}");

                break;

            case IngredientType.ingredientC:
                ingredientC++;

                Debug.Log($"IngredientA: {ingredientA} " + 
                    $"\nIngredientB: {ingredientB} " + 
                    $"\nIngredientC: {ingredientC}");

                break;
        }

        //UpdateProduct();

    }

    

    // Metodo pra determinar o nome do produto com base nos ingredientes adicionados
    //
    // NOTA: Talvez seja prudente o uso de um botão que "finaliza" o café para que o
    // código não rode toda vez que um ingrediente é acrescentado
    private void UpdateProduct() {
        
    }

}

