using UnityEngine;

public enum IngredientType {        // Enum pra facilitar a computação de cada ingrediente
    ingredientA,                    // Nomes provisórios, mudar depois!!
    ingredientB,
    ingredientC
}
public class Ingredient : MonoBehaviour
{
    // ===============================================================================
    // || Esse script fica no CONTAINER dos ingredientes, que ao clicados (tocados) ||
    // || instanciam um ingrediente a ser adicionado no produto                     ||
    // ===============================================================================

    [SerializeField]
    IngredientType ingredientType;

    // Prefab do ingrediente a ser instanciado
    public GameObject ingredientPrefab;

    // Referencia ao script de interação
    Interaction interaction;

    private void Awake() {
        interaction = GameObject.Find("Manager").GetComponent<Interaction>();                          // Busca o script de interação
    }

    // Metodo chamado em Interaction quando o jogador clica (toca) no container de ingredientes
    public void OnClicked() {
        GameObject inst = Instantiate(ingredientPrefab, interaction.cursorPos, Quaternion.identity);   // Cria a instancia
        inst.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 2;                    // Faz o sprite ser renderizado por cima do container
        interaction.StartCoroutine(interaction.DragIngredient(inst));                                  // Chama a corrotina em Interaction
    }

}
