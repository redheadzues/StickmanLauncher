using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private Sprite _spriteSoundOff;
    [SerializeField] private Sprite _spriteSoundOn;

    private Button _buttonSound;
    private static bool _isSoundPlay = true;

    private void Awake()
    {
        _buttonSound = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buttonSound.onClick.AddListener(OnButtonSoundClick);
        SetSprite();
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
            _isSoundPlay = false;
            SetSprite();
        }
        else
        {
            AudioListener.volume = 1;
            _isSoundPlay = true;
            SetSprite();
        }
    }

    private void SetSprite()
    {
        if(_isSoundPlay == true)
            _buttonSound.image.sprite = _spriteSoundOn;
        if(_isSoundPlay == false)
            _buttonSound.image.sprite = _spriteSoundOff;
    }
}
