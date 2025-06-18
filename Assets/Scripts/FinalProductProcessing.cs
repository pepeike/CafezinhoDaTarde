using System.Collections.Generic;
using UnityEngine;


public class FinalProductProcessing : MonoBehaviour {

    public string productName; // Nome do produto
    [HideInInspector]
    public int[] productProperties;

    // Dicionario que determina o nome do produto final com base nos ingredientes e processos utilizados
    public Dictionary<string, string> coffeeDict = new Dictionary<string, string> {
        {"0,0", "nada" },
        {"1,0", "café puro"},
        {"2,0", "café com açúcar"},
        {"3,0", "café com canela"},
        {"5,0", "café com leite"},
        {"7,0", "cappuccino"},
        {"1,1", "chá preto"},
        {"2,1", "chá com açúcar"},
        {"3,1", "chá com canela"},
        {"5,1", "chá latte"},
    };

    public bool occupied = false;

    // Ingredientes colocados no produto, determinam o nome do produto

    [SerializeField] int taste = 0;
    [SerializeField] int effect = 0;

    // Metodo chamado quando um ingrediente é adicionado
    public void OnPourDrink(int effect, int taste) {
        this.taste = taste; // Atribui o gosto do ingrediente
        this.effect += effect; // Atribui o efeito do ingrediente


    }

    public void OnPourLiquid(int effect) {
        this.effect += effect;
    }


    // Metodo pra determinar o nome do produto com base nos ingredientes adicionados
    //
    // NOTA: Talvez seja prudente o uso de um botão que "finaliza" o café para que o
    // código não rode toda vez que um ingrediente é acrescentado
    public void UpdateProduct() {
        int[] _ingreds = { taste, effect };                                          // Junta os ingredientes
                                                                                     //       e processos em 1 array (bools viram 1 ou 0)
        string _key = string.Join(",", _ingreds);                                  // Transforma o array em string pra ser usado com o dicionario
        if (coffeeDict.TryGetValue(_key, out string _name))                        // Ve se a combinação existe no dicionario
        {
            productName = _name;                                                   // Se existir, atualiza o nome do produto
        } else {
            productName = "Invalid";                                               // Se nao, atualiza pra indicar que a combinação nao é valida
        }
        UpdateSprite(); // Atualiza o sprite do produto final
        productProperties = _ingreds;

        Debug.Log(_key);
        Debug.Log(productName);
        Debug.Log(productProperties[0] + ", " + productProperties[1]);
    }

    [SerializeField]
    public Sprite[] productSprites = new Sprite[5]; // Lista de sprites do produto final
    public SpriteRenderer spr;

    private Dictionary<string, int> sprKeys = new Dictionary<string, int> {
        { "nada", 4 }, // Nada
        { "café puro", 0 }, // Café puro
        { "café com açúcar", 0 }, // Café com açúcar
        { "café com canela", 1 }, // Café com canela
        { "café com leite", 0 }, // Café com leite
        { "cappuccino", 0 }, // Cappuccino
        { "chá preto", 2 }, // Chá preto
        { "chá com açúcar", 2 }, // Chá com açúcar
        { "chá com canela", 3 }, // Chá com canela
        { "chá latte", 2 }  // Chá latte
    };

    public void UpdateSprite() {
        if (spr == null && productSprites == null) {
            return; // Verifica se o sprite renderer ou os sprites estão nulos
        }

        if (sprKeys.TryGetValue(productName, out int sprite)) {
            spr.sprite = productSprites[sprite]; // Atualiza o sprite do produto final com base no nome
        } else {
            spr.sprite = productSprites[4]; // Se não encontrar, usa o sprite de "nada"
        }
    }

    
}

