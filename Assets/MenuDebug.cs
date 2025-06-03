using UnityEngine;
using UnityEngine.UI;

public class MenuDebug : MonoBehaviour
{
    [SerializeField] private Button day2button;
    [SerializeField] private Button day3button;
    [SerializeField] private RectTransform day2rect;
    [SerializeField] private RectTransform day3rect;


    private void Start()
    {
        day2rect = day2button.GetComponent<RectTransform>();
        day3rect = day3button.GetComponent<RectTransform>();
    }

    public void SendAway()
    {
        day2button.transform.localPosition = new Vector2(0, -0);
        day3button.transform.localPosition = new Vector2(0, -0);
    }
    

}
