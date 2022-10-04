using UnityEngine;
using Lean.Localization;
using Agava.YandexGames;
using System.Collections;

[RequireComponent(typeof(LeanLocalization))]
public class LanguageSetter : MonoBehaviour
{
    private LeanLocalization _localization;

    private void Awake()
    {
        _localization = GetComponent<LeanLocalization>();
    }

#if !UNITY_EDITOR
    private IEnumerator Start()
    {


        while (YandexGamesSdk.IsInitialized != true)
        {
            yield return new WaitForSeconds(0.2f);
        }

        _localization.SetCurrentLanguage(YandexGamesSdk.Environment.i18n.lang);
    }
#endif
}
