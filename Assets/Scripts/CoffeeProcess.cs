using System.Collections;
using UnityEngine;

public enum ProcessType {
    processA,
    processB,
    processC
}

public class CoffeeProcess : MonoBehaviour {
    // Script para as maquinas que processam o café

    // Processo a ser feito (definido pelo inspetor na unity)
    [SerializeField]
    ProcessType process;

    // Tempo do processamento do café
    public float time;

    // Metodo chamado no script Interaction
    // Confere se o produto ja foi processado nessa maquina
    // Se nao tiver sido, ele processa
    public void OnDropProduct(FinalProductProcessing obj) {
        switch (process) {
            case ProcessType.processA:
                if (obj.processA) {
                    break;
                } else {
                    StartCoroutine(Processing(obj));
                }
                break;
            case ProcessType.processB:
                if (obj.processB) {
                    break;
                } else {
                    StartCoroutine(Processing(obj));
                }
                break;
            case ProcessType.processC:
                if (obj.processC) {
                    break;
                } else {
                    StartCoroutine(Processing(obj));
                }
                break;
        }
        return;
    }

    // Metodo para o processamento
    public IEnumerator Processing(FinalProductProcessing obj) {
        obj.occupied = true;                        // Deixa o café imovel durante o processo
        switch (process)                            // Decide qual booleana deve ser alterada no script FinalProductProcessing (scrript do café)
        {
            case ProcessType.processA:
                obj.processA = true;
                break;
            case ProcessType.processB:
                obj.processB = true;
                break;
            case ProcessType.processC:
                obj.processC = true;
                break;
        }
        yield return new WaitForSeconds(time);      // Espera o processo terminar
        obj.occupied = false;                       // Deixa o player mover o café novamente
    }

}
