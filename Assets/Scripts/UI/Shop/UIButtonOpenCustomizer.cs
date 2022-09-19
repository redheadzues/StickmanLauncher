using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonOpenCustomizer : MonoBehaviour
{
    [SerializeField] private UICustomizer _customizer;

    private Button _buttonOpenCustomizer;

    private void OnValidate()
    {
        _customizer = FindObjectOfType<UICustomizer>();
    }

    private void Awake()
    {
        _buttonOpenCustomizer = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buttonOpenCustomizer.onClick.AddListener(OnButtonOpenCustomizerClick);
        _customizer.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _buttonOpenCustomizer.onClick.RemoveListener(OnButtonOpenCustomizerClick);
    }

    private void OnButtonOpenCustomizerClick()
    {
        _customizer.gameObject.SetActive(true);
    }
}
