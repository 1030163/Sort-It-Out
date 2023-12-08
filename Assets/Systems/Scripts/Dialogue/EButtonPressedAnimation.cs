using System.Collections;
using UnityEngine;

public class EButtonPressedAnimation : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 startingSize;
    private Vector2 endSize;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        startingSize = rectTransform.sizeDelta;
        endSize = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - 30f);
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeSpriteSize());
    }

    private IEnumerator ChangeSpriteSize()
    {
        while (true)
        {
            rectTransform.sizeDelta = startingSize;
            yield return new WaitForSeconds(1f);
            rectTransform.sizeDelta = endSize;
            yield return new WaitForSeconds(1f);
        }
    }
}
