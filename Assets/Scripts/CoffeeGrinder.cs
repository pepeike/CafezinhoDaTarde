using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CoffeeGrinder : MonoBehaviour
{
    public enum GrinderState {
        Idle,
        Grinding,
        Finished
    }

    public GrinderState currentState = GrinderState.Idle;
    public Ingredient processedIngredient;
    public GameObject[] processedIngredPrefabs;
    public IngredientCarrier carrier;

    public Animator anim;

    //public GameObject groundIngredPrefab;

    public void StartGrinding(Ingredient ingred, IngredientCarrier _carrier) {
        // Aqui você pode adicionar a lógica para iniciar o processo de moagem
        // Por exemplo, você pode usar um Animator para animar a máquina de moer café
        // ou simplesmente esperar um tempo e depois chamar o método OnGrindingFinished.
        if (ingred == null || ingred.groundable == false || ingred.GetGround()) { // Verifica se o ingrediente é válido e se pode ser moído
            Debug.Log("Ingrediente inválido ou não moível.");
            Destroy(_carrier.gameObject); // Destrói o carrier se o ingrediente não for válido
            return;
        }
        Debug.Log("Iniciando moagem do ingrediente: " + ingred.GetIngredType());
        
        carrier = _carrier; // Recebe o carrier do ingrediente
        carrier.ToggleVisible(); // Desativa a visibilidade do ingrediente enquanto está sendo processado
        processedIngredient = ingred;
        processedIngredient.Grind(); // Marca o ingrediente como moído


        // Simulando o tempo de moagem
        StartCoroutine(GrindingProcess());
    }

    IEnumerator GrindingProcess() {
        // Muda o estado da máquina para "Grinding"
        // Aqui você pode adicionar animações ou efeitos sonoros
        anim.SetBool("isOn", true); // Ativa a animação de moagem
        currentState = GrinderState.Grinding;
        yield return new WaitForSeconds(2f); // Simula o tempo de moagem
        OnGrindingFinished();
    }

    private void OnGrindingFinished() {
        // Aqui você pode adicionar a lógica para o que acontece após a moagem
        // Por exemplo, você pode ativar um efeito visual ou sonoro
        Debug.Log("Moagem concluída!");
        currentState = GrinderState.Finished;
        anim.SetBool("isOn", false); // Desativa a animação de moagem

        // Muda o estado da máquina para "Finished"
        // Aqui você pode adicionar animações ou efeitos sonoros
    }

    public GameObject SpawnGroundIngred() {
        if (processedIngredient != null && currentState == GrinderState.Finished) {
            carrier.ToggleVisible(); // Ativa a visibilidade do ingrediente processado
            currentState = GrinderState.Idle; // Reseta o estado da máquina para Idle após a moagem

            Debug.Log(carrier.ingred.GetEffect());
            Debug.Log(carrier.ingred.GetGround());
            return carrier.transform.gameObject;
        } else {
            Debug.LogWarning("Nenhum ingrediente processado ou a máquina não está pronta.");
            return null;
        }
    }

}
