using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    private void Start()
    {

        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1;
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 400);

    }
}
