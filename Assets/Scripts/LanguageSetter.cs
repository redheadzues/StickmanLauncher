using UnityEngine;
using Lean.Localization;
using Agava.YandexGames;

public class LanguageSetter : MonoBehaviour
{
    [SerializeField] private LeanLocalization _localization;

    private void Start()
    {
        _localization.SetCurrentLanguage(YandexGamesSdk.Environment.i18n.lang);
    }
}
