using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informa��es de cada cliente
    public string[] DemandArray;
    public string[,] AnswerArray;
    private string Coffie;

    //Para criar este script � necessario as seguintes informa��es
    public Cliant(string[] DemandArray, string[,] AnswerArray /*Change to a diffrent Kind of Information*/)
    {
        this.DemandArray = DemandArray; //Pergunta do Cliente separada em partes
        this.AnswerArray = AnswerArray; //
    }
    public override string ToString()       // Retorna o tipo de caf� que o Cliente quer
    {
        return Coffie;
    }
}
