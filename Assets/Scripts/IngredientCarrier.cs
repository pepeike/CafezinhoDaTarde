using UnityEngine;

public class IngredientCarrier : MonoBehaviour {
    // Esse script fica nos prefabs de ingredientes
    // So serve pro FinalProductProcessing saber qual ingrediente esta sendo acrescentado

    public IngredientType ingredCarrierType; // Ingrediente a ser instanciado
    public Ingredient ingred; // Referencia ao ingrediente que esta sendo carregado
    public bool isVisible = true; // Se o ingrediente esta visivel ou nao

    public void SetIngredient(Ingredient ingredient) {
        ingredCarrierType = ingredient.GetIngredType(); // Seta o tipo do ingrediente
        ingred = ingredient.CopyIngredient(ingredient);
    }

    public void ToggleVisible() {
        isVisible = !isVisible; // Inverte o estado de visibilidade
        gameObject.SetActive(isVisible); // Ativa ou desativa o objeto
    }

}
