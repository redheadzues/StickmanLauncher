using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private Sprite _spriteSoundOff;
    [SerializeField] private Sprite _spriteSoundOn;

    private Button _buttonSound;
    private bool _isSoundPlay = true;

    private void Awake()
    {
        _buttonSound = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buttonSound.onClick.AddListener(OnButtonSoundClick);
    }

    private void OnDisable()
    {
        _buttonSound.onClick.RemoveListener(OnButtonSoundClick);
    }

    private void OnButtonSoundClick()
    {
        if(_isSoundPlay == true)
        {
            AudioListener.volume = 0;
            _buttonSound.image.sprite = _spriteSoundOff;
            _isSoundPlay = false;
        }
        else
        {
            AudioListener.volume = 1;
            _buttonSound.image.sprite = _spriteSoundOn;
            _isSoundPlay = true;
        }
    }
}
