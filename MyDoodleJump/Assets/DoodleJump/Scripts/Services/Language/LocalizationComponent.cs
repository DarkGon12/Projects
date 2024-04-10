using Scripts.Services.Language;
using UnityEngine;
using TMPro;

public class LocalizationComponent : MonoBehaviour, ILocalization
{
    public int LanguageIndex { get => LanguageIndex; set => TranslateText(value); }

    [SerializeField] private string _rusValue, _engValue, _turValue;
    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void SaveLanguage(int value)
    {
        PlayerPrefs.SetInt("Language", value);
    }

    private void TranslateText(int value)
    {
        if (value == 0)
            _textMesh.text = _rusValue;
        if(value == 1)
            _textMesh.text = _engValue;
        if (value == 2)
            _textMesh.text = _turValue;

        SaveLanguage(value);
    }
}