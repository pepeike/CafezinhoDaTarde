using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliant
{
    //script para guardar as informa��es de cada cliente
    public string Demand, Right, Wrong;
    private string Coffie;

    //Para criar este script � necessario as seguintes informa��es
    public Cliant(string CliantDemand, string Coffie, string Right, string Wrong)
    {
        Demand = CliantDemand; //Pergunta do Cliente
        this.Coffie = Coffie; //Identifica��o do produto requisitado pelo Cliente
        this.Right = Right; //Resposta do produto certo
        this.Wrong = Wrong; //resposta do produto errado
    }
    public override string ToString()       // Retorna o tipo de caf� que o Cliente quer
    {
        return Coffie;
    }
}
