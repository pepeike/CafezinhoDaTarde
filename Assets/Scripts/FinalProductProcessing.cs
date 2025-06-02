using System;
using System.Collections.Generic;
using UnityEngine;


public class FinalProductProcessing : MonoBehaviour
{

    public string productName; // Nome do produto
    public int[] productProperties;

    // Dicionario que determina o nome do produto final com base nos ingredientes e processos utilizados
    public Dictionary<string, string> coffeeDict = new Dictionary<string, string> {
        {"0,0", "café puro"},
        {"1,0", "café com açúcar"},
        {"2,0", "café com canela"},
        {"3,0", "café com leite"},
        {"4,0", "cappuccino"},
        {"0,1", "chá preto"},
        {"1,1", "chá com açúcar"},
        {"2,1", "chá com canela"},
        {"3,1", "chá latte"},
    };

    public bool occupied = false;

    // Ingredientes colocados no produto, determinam o nome do produto
    int taste = 0;
    int effect = 0;

    // Metodo chamado quando um ingrediente é adicionado
    public void OnPourDrink(int taste, int effect)
    {
        this.taste = taste; // Atribui o gosto do ingrediente
        this.effect = effect; // Atribui o efeito do ingrediente
        

    }



    // Metodo pra determinar o nome do produto com base nos ingredientes adicionados
    //
    // NOTA: Talvez seja prudente o uso de um botão que "finaliza" o café para que o
    // código não rode toda vez que um ingrediente é acrescentado
    public void UpdateProduct()
    {
        int[] _ingreds = { taste, effect };                                          // Junta os ingredientes
                                                                                   //       e processos em 1 array (bools viram 1 ou 0)
        string _key = string.Join(",", _ingreds);                                  // Transforma o array em string pra ser usado com o dicionario
        if (coffeeDict.TryGetValue(_key, out string _name))                        // Ve se a combinação existe no dicionario
        {
            productName = _name;                                                   // Se existir, atualiza o nome do produto
        }
        else
        {
            productName = "Invalid";                                               // Se nao, atualiza pra indicar que a combinação nao é valida
        }
        productProperties = _ingreds;

        Debug.Log(_key);
        Debug.Log(productName);
        Debug.Log(productProperties[0] + ", " + productProperties[1]);
    }

}

