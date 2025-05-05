using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadingAnim : MonoBehaviour
{
    public float dotTimer;
    public TMP_Text loadingtext;
    public int loadingState;

    private void Start()
    {
        loadingState = 1;
        dotTimer = 1.5f;
    }

    void Update()
    {
        dotTimer -= Time.deltaTime;

        if (dotTimer < 0)
        {
            
            switch (loadingState)
            {
                case  1:
                    loadingtext.text = new string("Loading.");
                    loadingState = 2;
                    dotTimer = 1.5f;
                    break;
                case 2:
                    loadingtext.text = new string("Loading..");
                    loadingState = 3;
                    dotTimer = 1.5f;
                    break;
                case 3:
                    loadingtext.text = new string("Loading...");
                    loadingState = 1;
                    dotTimer = 1.5f;
                    break;
            }
            
        }
    }
}
