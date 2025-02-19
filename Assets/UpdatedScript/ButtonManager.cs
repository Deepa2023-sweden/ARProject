using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField] private RawImage buttonImage;
    private int _itemId;
    private Sprite _buttonTexture;

    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    public int Itemid
    {
        set => _itemId = value;
    }

    void Start()
    {
        btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(SelectObject);
        }
    }

    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_itemId);
    }
}
