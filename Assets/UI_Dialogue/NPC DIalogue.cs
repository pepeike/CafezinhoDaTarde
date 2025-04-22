using UnityEngine;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine.UI;
using TMPro;

public class NPCDIalogue : MonoBehaviour
{
    public string[] dialogueNPC;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI nameNpc;

    public bool readyToSpeak;
    public bool startDialogue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //iniciar dialogo em cena
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!startDialogue)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNPC[dialogueIndex])
            {
                NextDialogue();
            }
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueNPC.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
        }
    }

            void StartDialogue()
            {
                nameNpc.text = "Random";
                startDialogue = true;
                dialogueIndex = 0;
                dialoguePanel.SetActive(true);
                StartCoroutine(ShowDialogue());

            }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach(char letter in dialogueNPC[dialogueIndex])
        {
            dialogueText.text += letter;
             yield return new WaitForSeconds(0.1f);
        }
    }
}
