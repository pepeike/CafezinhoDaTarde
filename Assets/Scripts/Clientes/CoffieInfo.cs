using UnityEngine;

public class CoffieInfo : MonoBehaviour
{
    // O objeto precisa possuir a Teg "Coffie" para o funcionamento correto
    // Script para guardar as informa��es de cada produto
    public string KindOfCoffie;
    // CoffieInfo nessecita de um tipo de caf�
    CoffieInfo(string KindOfCoffie) { this.KindOfCoffie = KindOfCoffie; }

    public override string ToString()       //Retorna o tipo de Caf� deste objeto
    {
        return KindOfCoffie;
    }
}
