using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioSourceScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected void PlaySound()
    {
        _audioSource.Play();
    }

    protected void IncreaseVolume(float startVolume = 0, float endVolume = 1, float secondsWork = 2)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnIncreaseVolume(startVolume, endVolume, secondsWork));
    }

    private IEnumerator OnIncreaseVolume(float startVolume, float endVolume, float secondsWork)
    {
        _audioSource.volume = startVolume;
        float step = 0.01f;
        int amountSteps = (int)(secondsWork / step);
        float increaseVolumeStep = (endVolume - startVolume) / amountSteps;

        for (int i = 0; i < amountSteps; i++)
        {
            _audioSource.volume += increaseVolumeStep;
            yield return new WaitForSeconds(step);
        }
    }
}
