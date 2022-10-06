using UnityEngine;
using UnityEngine.UI;

public class UIButtonsActivator : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private LevelEvent _eventer;

    private void OnValidate()
    {
        _buttons = GetComponentsInChildren<Button>();
        _eventer = FindObjectOfType<LevelEvent>();
    }

    private void OnEnable()
    {
        _eventer.Won += OnLevelFinish;
        _eventer.Defeated += OnLevelFinish;
    }

    private void OnDisable()
    {
        _eventer.Won -= OnLevelFinish;
        _eventer.Defeated -= OnLevelFinish;
    }

    private void OnLevelFinish()
    {
        for (int i = 0; i < _buttons.Length; i++)

            _buttons[i].gameObject.SetActive(true);
    }
}
