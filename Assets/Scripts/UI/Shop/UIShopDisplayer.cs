using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopDisplayer : MonoBehaviour
{
    [SerializeField] private Button _buttonCloseShop;
    [SerializeField] private Button _buttonOpenSkillsPanel;
    [SerializeField] private Button _buttonOpenSkinsPanel;
    [SerializeField] private GameObject _skillsPanel;
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private Color _targetActiveColor;

    private Color _baseColor;

    private void Awake()
    {
        _baseColor =  _buttonOpenSkillsPanel.image.color;
    }

    private void OnEnable()
    {
        OnButtonOpenSkillsPanelClick();
        _buttonCloseShop.onClick.AddListener(OnButtonCloseShopClick);
        _buttonOpenSkillsPanel.onClick.AddListener(OnButtonOpenSkillsPanelClick);
        _buttonOpenSkinsPanel.onClick.AddListener(OnButtonOpenSkinsPanelClick);
    }

    private void OnDisable()
    {
        _buttonCloseShop.onClick.RemoveListener(OnButtonCloseShopClick);
        _buttonOpenSkillsPanel.onClick.RemoveListener(OnButtonOpenSkillsPanelClick);
        _buttonOpenSkinsPanel.onClick.RemoveListener(OnButtonOpenSkinsPanelClick);
    }

    private void OnButtonCloseShopClick()
    {
        gameObject.SetActive(false);
    }

    private void OnButtonOpenSkinsPanelClick()
    {
        _skinsPanel.SetActive(true);
        _skillsPanel.SetActive(false);
        _buttonOpenSkinsPanel.image.color = _targetActiveColor;
        _buttonOpenSkillsPanel.image.color = _baseColor;
    }

    private void OnButtonOpenSkillsPanelClick()
    {
        _skinsPanel.SetActive(false);
        _skillsPanel.SetActive(true);
        _buttonOpenSkinsPanel.image.color = _baseColor;
        _buttonOpenSkillsPanel.image.color = _targetActiveColor;
    }

}
