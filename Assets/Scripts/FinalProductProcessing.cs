using System;
using System.Collections.Generic;
using UnityEngine;


public class FinalProductProcessing : MonoBehaviour
{

    public string productName; // Nome do produto
    public int[] productProperties;

    // Dicionario que determina o nome do produto final com base nos ingredientes e processos utilizados
    public Dictionary<string, string> coffeeDict = new Dictionary<string, string> {
        {"1,1,0,0,0", "caféA"},
        {"1,2,0,0,0", "caféB"}
    };

    public bool occupied = false;

    // Ingredientes colocados no produto, determinam o nome do produto
    int taste = 0;
    int effect = 0;
    

    // Processos feitos no produto, tambem determinam o nome (até o momento inutilizados)
    public bool processA = false;
    public bool processB = false;
    public bool processC = false;

    // Metodo chamado quando um ingrediente é adicionado
    public void OnDropIngredient(IngredientCarrier drop)
    {
        IngredientType dropIngredient = drop.type;
        switch (dropIngredient)
        {                           // Switch pra determinar qual ingrediente deve ser adicionado
            case IngredientType.LavaShroom:
                taste--;

                //Debug.Log($"IngredientA: {ingredientA} " +
                //    $"\nIngredientB: {ingredientB} " +
                //    $"\nIngredientC: {ingredientC}");

                break;

            case IngredientType.NethSucralose:
                taste++;

                //Debug.Log($"IngredientA: {ingredientA} " +
                //    $"\nIngredientB: {ingredientB} " +
                //    $"\nIngredientC: {ingredientC}");

                break;

            case IngredientType.SkullTwig:
                effect--;

                //Debug.Log($"IngredientA: {ingredientA} " +
                //    $"\nIngredientB: {ingredientB} " +
                //    $"\nIngredientC: {ingredientC}");

                break;

            case IngredientType.SourTree:
                effect++;

                //Debug.Log($"IngredientA: {ingredientA} " +
                //    $"\nIngredientB: {ingredientB} " +
                //    $"\nIngredientC: {ingredientC}");

                break;
        }
        //UpdateProduct();
    }



    // Metodo pra determinar o nome do produto com base nos ingredientes adicionados
    //
    // NOTA: Talvez seja prudente o uso de um botão que "finaliza" o café para que o
    // código não rode toda vez que um ingrediente é acrescentado
    public void UpdateProduct()
    {
        int[] _ingreds = { taste, effect };                                          // Junta os ingredientes
                           //processA ? 1 : 0, processB ? 1 : 0, processC ? 1 : 0 }; //       e processos em 1 array (bools viram 1 ou 0)
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
    }

    /// <summary>
    /// ///////////// Modefied By RLH107 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public void ResetTasteEffect()
    {
        taste = 0; effect = 0;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

