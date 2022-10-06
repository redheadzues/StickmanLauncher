using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonOpenShop : MonoBehaviour
{
    [SerializeField] private UIShopDisplayer _shop;

    private Button _buttonOpenShop;

    private void OnValidate()
    {
        _shop = FindObjectOfType<UIShopDisplayer>();
    }

    private void Awake()
    {
        _buttonOpenShop = GetComponent<Button>();
        _shop.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buttonOpenShop.onClick.AddListener(OnButtonOpenCustomizerClick);

    }

    private void OnDisable()
    {
        _buttonOpenShop.onClick.RemoveListener(OnButtonOpenCustomizerClick);
    }

    private void OnButtonOpenCustomizerClick()
    {
        _shop.gameObject.SetActive(true);
    }
}
