using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonCustomize : MonoBehaviour
{
    [SerializeField] private UICustomizer _uiCustomizer;

    private Button _buttonCustomize;

    private void OnValidate()
    {
        _uiCustomizer = FindObjectOfType<UICustomizer>();
    }

    private void Awake()
    {
        _buttonCustomize = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buttonCustomize.onClick.AddListener(OnButtonCustimizeClick);
    }

    private void OnDisable()
    {
        _buttonCustomize.onClick.RemoveListener(OnButtonCustimizeClick);
    }

    private void OnButtonCustimizeClick()
    {
        _uiCustomizer.gameObject.SetActive(true);
    }

}
