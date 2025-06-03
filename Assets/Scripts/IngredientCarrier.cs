using UnityEngine;

public class IngredientCarrier : MonoBehaviour {
    // Esse script fica nos prefabs de ingredientes
    // So serve pro FinalProductProcessing saber qual ingrediente esta sendo acrescentado

    
    public IngredientType ingredCarrierType; // Ingrediente a ser instanciado
    public Ingredient ingred; // Referencia ao ingrediente que esta sendo carregado
    public bool isVisible = true; // Se o ingrediente esta visivel ou nao
    private Vector2 milkPos; // Posição do leite, usada para reposicionar o leite após o preparo

    public void SetIngredient(Ingredient ingredient) {
        ingredCarrierType = ingredient.GetIngredType(); // Seta o tipo do ingrediente
        ingred = ingredient.CopyIngredient(ingredient);
    }

    public void ToggleVisible() {
        isVisible = !isVisible; // Inverte o estado de visibilidade
        gameObject.SetActive(isVisible); // Ativa ou desativa o objeto
    }

    public void ResetPos() {
        if (ingredCarrierType == IngredientType.Milk) {
            transform.position = milkPos; // Reposiciona o leite na posição inicial
        }
    }

    public void Start() {
        if (ingredCarrierType == IngredientType.Milk) {
            ingred = IngredientSpawner.Milk; // Seta o ingrediente como leite
            Debug.Log(ingred.GetIngredType());
            milkPos = transform.position; // Armazena a posição inicial do leite
        }
    }

}
