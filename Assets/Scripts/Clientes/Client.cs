using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informações de cada cliente
    public string[] DemandArray;
    public string[,] AnswerArray;
    private string Coffie;

    //Para criar este script é necessario as seguintes informações
    public Cliant(string[] DemandArray, string[,] AnswerArray /*Change to a diffrent Kind of Information*/)
    {
        this.DemandArray = DemandArray; //Pergunta do Cliente separada em partes
        this.AnswerArray = AnswerArray; //
    }
    public override string ToString()       // Retorna o tipo de café que o Cliente quer
    {
        return Coffie;
    }
}
