using UnityEngine;
using UnityEngine.UI;


public class CreditosApres : MonoBehaviour
{
    [Header("Configuração de Scroll")]
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float scrollLerpSpeed = 0.1f;
    [SerializeField] private float selectedScale = 1.2f;
    [SerializeField] private float unselectedScale = 0.9f;

    private float scrollPos = 0;
    private float[] childPositions;
    private float distanceBetweenChildren;
    private Transform[] children;

    void Start()
    {
        InitializeChildrenPositions();
    }

    void Update()
    {
        HandleScrollInput();
        UpdateScrollPosition();
        UpdateChildrenScales();
    }

    private void InitializeChildrenPositions()
    {
        children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i);
        }

        childPositions = new float[children.Length];
        distanceBetweenChildren = 1f / (childPositions.Length - 1f);

        for (int i = 0; i < childPositions.Length; i++)
        {
            childPositions[i] = distanceBetweenChildren * i;
        }
    }

    private void HandleScrollInput()
    {
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.value;
        }
    }

    private void UpdateScrollPosition()
    {
        if (!Input.GetMouseButton(0))
        {
            for (int i = 0; i < childPositions.Length; i++)
            {
                if (IsPositionNearChild(scrollPos, i))
                {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, childPositions[i], scrollLerpSpeed);
                    break;
                }
            }
        }
    }

    private void UpdateChildrenScales()
    {
        for (int i = 0; i < children.Length; i++)
        {
            bool isSelected = IsPositionNearChild(scrollPos, i);
            float targetScale = isSelected ? selectedScale : unselectedScale;

            children[i].localScale = Vector2.Lerp(
                children[i].localScale,
                new Vector2(targetScale, targetScale),
                scrollLerpSpeed
            );
        }
    }

    private bool IsPositionNearChild(float position, int childIndex)
    {
        float halfDistance = distanceBetweenChildren / 2f;
        return position < childPositions[childIndex] + halfDistance &&
               position > childPositions[childIndex] - halfDistance;
    }
}