using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informações de cada cliente
    public string Demand, Right, Wrong;
    private string Coffie;

    //Para criar este script é necessario as seguintes informações
    public Cliant(string CliantDemand, string Coffie, string Right, string Wrong)
    {
        Demand = CliantDemand; //Pergunta do Cliente
        this.Coffie = Coffie; //Identificação do produto requisitado pelo Cliente
        this.Right = Right; //Resposta do produto certo
        this.Wrong = Wrong; //resposta do produto errado
    }
    public override string ToString()       // Retorna o tipo de café que o Cliente quer
    {
        return Coffie;
    }
}
