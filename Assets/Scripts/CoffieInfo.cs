using UnityEngine;

public class CoffieInfo : MonoBehaviour
{
    // O objeto precisa possuir a Teg "Coffie" para o funcionamento correto
    // Script para guardar as informações de cada produto
    public string KindOfCoffie;
    // CoffieInfo nessecita de um tipo de café
    CoffieInfo(string KindOfCoffie) { this.KindOfCoffie = KindOfCoffie; }

    public override string ToString()       //Retorna o tipo de Café deste objeto
    {
        return KindOfCoffie;
    }
}
