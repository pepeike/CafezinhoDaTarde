using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informa��es de cada cliente
    public string[] DemandArray;
    public List<string>[] Answers;
    private string Coffie;

    //Para criar este script � necessario as seguintes informa��es
    public Cliant(string[] DemandArray, List<string>[] Answers /*Change to a diffrent Kind of Information*/)
    {
        this.DemandArray = DemandArray; //Pergunta do Cliente separada em partes
        this.Answers = Answers; //
    }
    public override string ToString()       // Retorna o tipo de caf� que o Cliente quer
    {
        return Coffie;
    }
}
