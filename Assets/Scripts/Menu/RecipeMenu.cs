using UnityEngine;
using UnityEngine.UI;

public class RecipeMenu : MonoBehaviour {

    public Sprite[] recipeImages;
    public int currentRecipeIndex = 0;
    public Image activeImageRef;

    private void Start() {
        UpdateImg();
    }

    private void UpdateImg() {
        activeImageRef.sprite = recipeImages[currentRecipeIndex];
    }

    public void OnImgForward() {
        currentRecipeIndex++;
        if (currentRecipeIndex >= recipeImages.Length) {
            currentRecipeIndex = 0; // Loop back to the first image
        }
        UpdateImg();
    }

    public void OnImgBackward() {
        currentRecipeIndex--;
        if (currentRecipeIndex < 0) {
            currentRecipeIndex = recipeImages.Length - 1; // Loop back to the last image
        }
        UpdateImg();
    }

}
