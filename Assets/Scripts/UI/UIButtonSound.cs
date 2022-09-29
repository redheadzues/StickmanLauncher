using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] private Sprite _spriteSoundOff;
    [SerializeField] private Sprite _spriteSoundOn;

    private Button _buttonSound;

    private void Awake()
    {
        _buttonSound = GetComponent<Button>();
        AudioListener.volume = SaveProgress.VolumeValue;
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
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            SaveProgress.VolumeValue = AudioListener.volume;
            SetSprite();
        }
        else
        {
            AudioListener.volume = 1;
            SaveProgress.VolumeValue = AudioListener.volume;
            SetSprite();
        }
    }

    private void SetSprite()
    {
        if(AudioListener.volume == 1)
            _buttonSound.image.sprite = _spriteSoundOn;
        if (AudioListener.volume == 0)
            _buttonSound.image.sprite = _spriteSoundOff;
    }
}
