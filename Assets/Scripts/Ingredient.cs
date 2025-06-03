using UnityEngine;

public enum IngredientType {        // Enum pra facilitar a computação de cada ingrediente
    LavaShroom,                    // Nomes provisórios, mudar depois!!
    NethSucralose,
    SkullTwig,
    SourTree,
    Water,
    Milk
}


public class Ingredient
{
    IngredientType type;        // Tipo do ingrediente
    public bool groundable;        // Se o ingrediente pode ser moído ou não
    bool isGround;            // Se o ingrediente foi moído ou não
    public bool isBean;            // true = café, false = chá
    int effect;           // Efeito do ingrediente

    public bool isLiquid; // Se o ingrediente é líquido (agua ou leite)
    

    public Ingredient(IngredientType type, bool groundable, bool isBean, int effect) {
        this.type = type;
        this.groundable = groundable;
        isGround = false;
        this.isBean = isBean;
        this.effect = effect;
        this.isLiquid = false;
        
    }

    public Ingredient(IngredientType type, int effect, bool isLiquid) { // Construtor para ingredientes líquidos (água ou leite)
        this.type = type;
        this.groundable = false; // Ingredientes líquidos não são moíveis
        isGround = false;
        this.isBean = false; // Ingredientes líquidos não são grãos
        this.effect = effect;
        this.isLiquid = isLiquid;
        
    }


public void Grind() {
        isGround = true;
    }

    public Ingredient CopyIngredient(Ingredient ingredient) {
        if (ingredient.isLiquid) {
            return new Ingredient(ingredient.type, ingredient.effect, ingredient.isLiquid);
        }
        return new Ingredient(ingredient.type, ingredient.groundable, ingredient.isBean, ingredient.effect);
    }

    public IngredientType GetIngredType() {
        return type;
    }

    public bool GetGround() {
        return isGround;
    }

    public int GetEffect() {
        return effect;
    }

    

}