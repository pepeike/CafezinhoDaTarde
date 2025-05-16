using UnityEngine;
using TMPro;
using System.Collections;
using System;
public class TypeTextAnimation : MonoBehaviour
{
    public Action typeFinished;

    // Esse script faz parte da animação de das letras, como velocidade e texto a ser executado
    public float typeDelay = 0.07f;//adicione o valor de velocidade

    public TextMeshProUGUI textObject;


    public string fullText;

    Coroutine coroutine;

    void Start()
    {
      
    }

    public void StartTyping()
    {
        coroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
        typeFinished?.Invoke();
    }

    public void Skip()
    {
        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;
    }
}
