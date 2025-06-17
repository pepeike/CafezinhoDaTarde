using System.Collections.Generic;
using UnityEngine;


public class IngredientSpawner : MonoBehaviour
{
    // ===============================================================================
    // || Esse script fica no CONTAINER dos ingredientes, que ao clicados (tocados) ||
    // || instanciam um ingrediente a ser adicionado no produto                     ||
    // ===============================================================================

    [SerializeField]
    IngredientType ingredientType;

    public static Ingredient LavaShroom = new Ingredient(IngredientType.LavaShroom, true, true, 1);        // Ingrediente do tipo LavaShroom
    public static Ingredient SkullTwig = new Ingredient(IngredientType.SkullTwig, true, false, 1);        // Ingrediente do tipo SkullTwig
    public static Ingredient SourTree = new Ingredient(IngredientType.SourTree, true, true, 1);           // Ingrediente do tipo SourTree
    public static Ingredient NethSucralose = new Ingredient(IngredientType.NethSucralose, false, false, 1);// Ingrediente do tipo NethSucralose
    public static Ingredient Milk = new Ingredient(IngredientType.Milk, 3, true);                    // Ingrediente do tipo Milk (leite)

    public Ingredient ingred;        // Ingrediente a ser instanciado


    public Dictionary<IngredientType, Ingredient> ingredientDict = new Dictionary<IngredientType, Ingredient> {
        {IngredientType.LavaShroom, LavaShroom},
        {IngredientType.SkullTwig, SkullTwig},
        {IngredientType.SourTree, SourTree},
        {IngredientType.NethSucralose, NethSucralose}
    };



    // Prefab do ingrediente a ser instanciado
    public GameObject ingredientPrefab;

    // Referencia ao script de interação
    Interaction interaction;

    private void Awake() {
        interaction = GameObject.Find("S_Manager").GetComponent<Interaction>();                          // Busca o script de interação
    }

    // Metodo chamado em Interaction quando o jogador clica (toca) no container de ingredientes
    public void OnClicked() {
        GameObject inst = Instantiate(ingredientPrefab, interaction.cursorPos, Quaternion.identity);   // Cria a instancia
        if (ingredientDict.ContainsKey(ingredientType)) { // Verifica se o tipo de ingrediente existe no dicionario
            inst.GetComponent<IngredientCarrier>().SetIngredient(ingredientDict[ingredientType]);             // Seta o ingrediente na instancia
        } else {
            Debug.LogError("Tipo de ingrediente não encontrado no dicionário.");
        }


        inst.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 2;                    // Faz o sprite ser renderizado por cima do container
        interaction.StartCoroutine(interaction.DragIngredient(inst));                                  // Chama a corrotina em Interaction
    }

}
