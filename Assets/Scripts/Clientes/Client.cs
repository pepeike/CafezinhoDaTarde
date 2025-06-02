using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informações de cada cliente
    public string[] DemandArray;
    public List<string>[] Answers;
    private string Coffie;

    //Para criar este script é necessario as seguintes informações
    public Cliant(string[] DemandArray, List<string>[] Answers /*Change to a diffrent Kind of Information*/)
    {
        this.DemandArray = DemandArray; //Pergunta do Cliente separada em partes
        this.Answers = Answers; //
    }
    public override string ToString()       // Retorna o tipo de café que o Cliente quer
    {
        return Coffie;
    }
}
