using UnityEngine;

public enum IngredientType {
    ingredientA,
    ingredientB,
    ingredientC
}
public class Ingredient : MonoBehaviour
{

    

    public IngredientType ingredientType;

    public GameObject ingredientPrefab;

    //GameObject manager;
    Interaction interaction;

    private void Awake() {
        //manager = GameObject.Find("Manager");
        interaction = GameObject.Find("Manager").GetComponent<Interaction>();
    }

    public void OnClicked() {
        GameObject inst = Instantiate(ingredientPrefab, interaction.cursorPos, Quaternion.identity);
        inst.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 2;
        interaction.StartCoroutine(interaction.DragIngredient(inst));
    }

}
