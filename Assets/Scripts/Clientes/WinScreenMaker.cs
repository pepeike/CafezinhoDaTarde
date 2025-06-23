using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScreenMaker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int numOfHappyCliants = 0;
    private float numDivided;
    public GameObject WinnObject, star1, star2, star3; public TextMeshProUGUI TextClientesSatisfeitos; public TextMeshProUGUI TextTotalCliants;
    private float typeDelay = 0.07f;

    public void CallWinScreen(List<Cliant> cliants)
    {
        numOfHappyCliants = 0;
        numDivided = cliants.Count / 2;
        foreach(Cliant cliant in cliants)   
        {
            if(cliant.isCorect == true)
            {
                numOfHappyCliants++;
            }
        }
        // call screen
        WinnObject.SetActive(true);
        StartCoroutine(TypeText(TextClientesSatisfeitos, "Clientes Satisfeitos: "+ numOfHappyCliants)); StartCoroutine(TypeText(TextTotalCliants, "Número de Clientes: "+ cliants.Count));
        
        //   O SetActive é para teste//
        //   O SetActive é para teste//
        //   O SetActive é para teste//
        //   O SetActive é para teste//
        
        star1.SetActive(true);
        if (numOfHappyCliants > numDivided) { /*set 2 star*/ star2.SetActive(true); }
        if(numOfHappyCliants == cliants.Count) { /*set 3 star*/ star3.SetActive(true); }
    }

    private IEnumerator TypeText(TextMeshProUGUI Text, string TextToWrite)
    {
        Text.text = TextToWrite;
        Text.maxVisibleCharacters = 0;
        for (int i = 0; i <= Text.text.Length; i++)
        {
            Text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
        //typeFinished?.Invoke();

    }

    public void CallMenu()
    {
        SceneManager.LoadScene("MenuProposal");
    }
}
