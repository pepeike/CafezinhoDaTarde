using System;
using System.Collections;
using UnityEngine;

public class CoffeeBrewer : MonoBehaviour
{
    public enum BrewerState {
        Idle,
        Brewing,
        Finished
    }

    public BrewerState currentState = BrewerState.Idle;
    public Ingredient processedIngredient;
    public IngredientCarrier carrier;
    public Ingredient liquidIngredient;
    //public IngredientCarrier liquidCarrier;
    public FinalProductProcessing cup;

    public void OnDropIngred(Ingredient ingred, IngredientCarrier carry) {
        if (!ingred.isLiquid) {
            liquidIngredient = ingred; // Armazena o ingrediente l�quido (��gua ou leite)
            carrier = carry; // Recebe o carrier do ingrediente
            carrier.transform.position += new Vector3(-200, -200, 0);
            //carrier.ToggleVisible(); // Desativa a visibilidade do ingrediente enquanto está sendo processado
            StartCoroutine(BrewingProcess());
        } else if (ingred.isLiquid) {
            processedIngredient = ingred; // Armazena o ingrediente seco (gr��o de caf�� ou ch��)
            StartCoroutine(MilkProcess());
        }

        

        
        
        

    }

    public void OnDropCup(FinalProductProcessing fpp) {
        cup = fpp; // Recebe a instância do copo onde o produto final será colocado
        if (currentState == BrewerState.Finished) {
            OnBrewingFinished(); // Se o preparo já estiver concluído, chama o método de finalização
        } else {
            Debug.Log("Aguardando preparo da bebida...");
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

    private void OnMilkFinished() {
        if (cup != null) {
            int outEffect = liquidIngredient.GetEffect();
            cup.OnPourLiquid(outEffect);
        }
    }

    public void OnBrewingFinished() {
        currentState = BrewerState.Finished;
        Debug.Log("Preparo concluído!");
        // Aqui você pode adicionar a lógica para o que acontece após o preparo
        // Por exemplo, você pode ativar um efeito visual ou sonoro
        // Adiciona o ingrediente processado ao copo
        if (cup != null) {
            
            //int outEffect = processedIngredient.GetEffect();
            //int outTaste = processedIngredient.isBean ? 0 : 1; // Efeito do ingrediente processado

            cup.OnPourDrink(processedIngredient.isBean ? 0 : 1, processedIngredient.GetEffect());
            carrier.ToggleVisible();
            Invoke("Flush", 2f); // Reseta o estado do brewer e limpa os ingredientes
        }
    }

    

    public void Flush() {
        // Reseta o estado do brewer e limpa os ingredientes
        currentState = BrewerState.Idle;
        processedIngredient = null;
        liquidIngredient = null;
        carrier = null;
        cup = null;
        Debug.Log("Brewer resetado.");
    }

}
