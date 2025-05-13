using UnityEngine;
using UnityEngine.UI;



public class BGScroll : MonoBehaviour
{
    public RawImage imgtoScroll;
    public float _x, _y;

    private void Update()
    {
        imgtoScroll.uvRect = new Rect(imgtoScroll.uvRect.position +  new Vector2 (_x, _y)*Time.deltaTime,imgtoScroll.uvRect.size);
    }
}
