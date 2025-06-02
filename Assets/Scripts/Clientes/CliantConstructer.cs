using System.Collections.Generic;
using UnityEngine;

public class CliantConstructer
{
    private List<Cliant> cliants;

    private string[] A = { "A1 A", "A1 B", "A1 C", "A1 D", "A1 E" };
    private string[] B = { "A2 A", "A2 B", "A2 C", "A2 D", "A2 E" };
    private string[] C = { "A3 A", "A3 B", "A3 C", "A3 D", "A3 E" };
    private string[] D = { "A4 A", "A4 B", "A4 C", "A4 D", "A4 E" };
    private List<string>[] A1 = new List<string>[4];
    private List<string>[] A2 = new List<string>[4];
    private List<string>[] A3 = new List<string>[4];
    private List<string>[] A4 = new List<string>[4];
    public CliantConstructer()
    {
        cliants = new List<Cliant>();
        A1[0] = new List<string>() { "A1 R1 P1", "A1 R1 P2", "A1 R1 P3" };
        A1[1] = new List<string>() { "A1 R2 P1", "A1 R2 P2", "A1 R2 P3", "A1 R2 P4" };
        A1[2] = new List<string>() { "A1 R3 P1", "A1 R3 P2" };
        A1[3] = new List<string>() { "A1 R4 P1" };

        A2[0] = new List<string>() { "A2 R1 P1", "A2 R1 P2", "A2 R1 P3" };
        A2[1] = new List<string>() { "A2 R2 P1", "A2 R2 P2", "A2 R2 P3", "A2 R2 P4" };
        A2[2] = new List<string>() { "A2 R3 P1", "A2 R3 P2" };
        A2[3] = new List<string>() { "A2 R4 P1" };

        A3[0] = new List<string>() { "A3 R1 P1", "A3 R1 P2", "A3 R1 P3" };
        A3[1] = new List<string>() { "A3 R2 P1", "A3 R2 P2", "A3 R2 P3", "A3 R2 P4" };
        A3[2] = new List<string>() { "A3 R3 P1", "A3 R3 P2" };
        A3[3] = new List<string>() { "A3 R4 P1" };

        A4[0] = new List<string>() { "A4 R1 P1", "A4 R1 P2", "A4 R1 P3" };
        A4[1] = new List<string>() { "A4 R2 P1", "A4 R2 P2", "A4 R2 P3", "A4 R2 P4" };
        A4[2] = new List<string>() { "A4 R3 P1", "A4 R3 P2" };
        A4[3] = new List<string>() { "A4 R4 P1" };

        cliants.Add(new Cliant(A, A1));
        cliants.Add(new Cliant(B, A2));
        cliants.Add(new Cliant(C, A3));
        cliants.Add(new Cliant(D, A4));
    }
    public List<Cliant> ReturnCliants()
    {
        return cliants;
    }
}
