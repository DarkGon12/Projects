using Scripts.Services.Language;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationController : MonoBehaviour
{
    private List<ILocalization> _localization = new List<ILocalization>();

    private void Start()
    {
        InitializationLocalization();
    }

    private void InitializationLocalization()
    {
        var LocalizationComponents = FindObjectsOfType<LocalizationComponent>();

        for (int i = 0; i < LocalizationComponents.Length; i++)
            _localization.Add(LocalizationComponents[i].GetComponent<ILocalization>());

        LoadSetting();
    }

    private void LoadSetting()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            ChangeLanguage(PlayerPrefs.GetInt("Language"));
        }
    }

    public void ChangeLanguage(int index)
    {
        for (int i = 0; i < _localization.Count; i++)
        {
            _localization[i].LanguageIndex = index;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        InitializationLocalization();
    }
}