using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
   [SerializeField]private RawImage imgtoscroll;
   [SerializeField] private float _x, _y;

    private void Update()
    {
        imgtoscroll.uvRect = new Rect(imgtoscroll.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, imgtoscroll.uvRect.size);
    }
}
