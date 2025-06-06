using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBrewer : MonoBehaviour {
    public enum BrewerState {
        Idle,
        Brewing,
        Finished
    }

    public BrewerState currentState = BrewerState.Idle;
    public Ingredient processedIngredient = null;
    private List<int> procIngreds = new List<int>();
    private List<IngredientCarrier> ingredCarriers = new List<IngredientCarrier>();
    public IngredientCarrier carrier = null;
    public Ingredient liquidIngredient = null;
    //public IngredientCarrier liquidCarrier;
    public FinalProductProcessing cup;

    public void OnDropIngred(Ingredient ingred, IngredientCarrier carry) {
        if (ingred.isLiquid == false && ingred.GetGround()) {
            processedIngredient = ingred;
            procIngreds.Add(ingred.GetEffect()); // Adiciona o efeito do ingrediente processado
            ingredCarriers.Add(carry); // Recebe o carrier do ingrediente
            carry.ToggleVisible(); // Desativa a visibilidade do ingrediente enquanto está sendo processado
            //StartCoroutine(BrewingProcess());
            return;
        } else if (ingred.isLiquid == false && !ingred.GetGround()) {
            Destroy(carry.gameObject);
            Debug.Log("Ingrediente precisa ser moído.");
            return;
        }

        if (ingred.isLiquid == true) {
            liquidIngredient = ingred;
            procIngreds.Add(ingred.GetEffect()); // Adiciona o efeito do ingrediente líquido
            //StartCoroutine(MilkProcess());
        }
    }

    public void OnDropCup(FinalProductProcessing fpp) {
        cup = fpp; // Recebe a instância do copo onde o produto final será colocado
        if (currentState == BrewerState.Finished) {
            OnBrewingFinished();
        } else {
            Debug.Log("Aguardando preparo da bebida...");
        }
    }

    public void OnPress() {
        if (currentState == BrewerState.Idle) {
            if (processedIngredient == null || liquidIngredient == null) {
                Debug.Log("Aguardando ingredientes para iniciar o preparo.");
            } else if (liquidIngredient != null) {
                StartCoroutine(BrewingProcess());
                Debug.Log(procIngreds.Count + " ingredientes processados.");
            }
        } else if (currentState == BrewerState.Brewing) {
            Debug.Log("Já está preparando a bebida.");
        } else if (currentState == BrewerState.Finished) {
            Debug.Log("O preparo já foi concluído. Por favor, despeje a bebida no copo.");
        }
    }

    IEnumerator BrewingProcess() {
        currentState = BrewerState.Brewing;
        Debug.Log("Iniciando preparo da bebida...");
        // Simula o tempo de preparo
        yield return new WaitForSeconds(3f);
        OnBrewingFinished();
    }

    IEnumerator MilkProcess() {
        currentState = BrewerState.Brewing;
        yield return new WaitForSeconds(3f);
        OnMilkFinished();
    }

    public void OnMilkFinished() {
        currentState = BrewerState.Finished;
        Debug.Log("Preparo Concluido");
        if (cup != null) {
            int outEffect = liquidIngredient.GetEffect();
            cup.OnPourLiquid(outEffect);
        }
    }

    public void OnBrewingFinished() {
        currentState = BrewerState.Finished;
        Debug.Log("Preparo concluído!");
        bool brewed = false;
        int outEffect = 0;

        if (!brewed) {
            for (int i = 0; i < procIngreds.Count; i++) {
                outEffect += procIngreds[i]; // Soma os efeitos dos ingredientes processados
            }
            brewed = true;
        }
        
        // Aqui você pode adicionar a lógica para o que acontece após o preparo
        // Por exemplo, você pode ativar um efeito visual ou sonoro
        // Adiciona o ingrediente processado ao copo
        if (cup != null) {
            
            //int outEffect = processedIngredient.GetEffect();
            //int outTaste = processedIngredient.isBean ? 0 : 1; // Efeito do ingrediente processado
            
            cup.OnPourDrink(processedIngredient.isBean ? 0 : 1, outEffect);

            //cup.OnPourDrink(processedIngredient.isBean ? 0 : 1, processedIngredient.GetEffect());
            //carrier.ToggleVisible();
            brewed = false;
            Invoke("Flush", 1f); // Reseta o estado do brewer e limpa os ingredientes
        }
    }

    public void ResetCup() {
        if (cup != null) {
            cup = null; // Limpa a referência ao copo
            Debug.Log("Copo resetado.");
        }
    }

    public void Flush() {
        // Reseta o estado do brewer e limpa os ingredientes
        for (int i = 0; i < ingredCarriers.Count; i++) {
            if (ingredCarriers[i] != null) {
                Destroy(ingredCarriers[i]);
            }
        }
        ingredCarriers.Clear(); // Limpa a lista de carriers
        currentState = BrewerState.Idle;
        processedIngredient = null;
        liquidIngredient = null;
        carrier = null;
        cup = null;

        Debug.Log("Brewer resetado.");
    }

}
