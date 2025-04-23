using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    Image backGround;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;

    public float speed = 10f;
    bool open = false;


    void Awake()
    {
        backGround = transform.GetChild(0).GetComponent<Image>(); 
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>(); 
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>(); 
    }

    void Update()
    {if (open)
        {
            backGround.fillAmount = Mathf.Lerp(backGround.fillAmount, 1, speed * Time.deltaTime);

        }
        else
        {
            backGround.fillAmount = Mathf.Lerp(backGround.fillAmount,0, speed * Time.deltaTime);
        }
        
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void Enable()
    {
        backGround.fillAmount = 0;
        open = true;
    }
    public void Disable()
    { 
        open = false;
        nameText.text = "";
        talkText.text = "";
    }

}
