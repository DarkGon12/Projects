using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _changesText;

    public void ChangeRus()
    {
        _changesText[0].text = "Играть";
        _changesText[1].text = "Настройки";
        _changesText[2].text = "Выход";
        _changesText[3].text = "   Настройки";
        _changesText[4].text = "Звук";
        _changesText[5].text = "Музыка";
        _changesText[6].text = "   Уровни";
        _changesText[7].text = "Продолжить";
        _changesText[8].text = "В меню";
        _changesText[9].text = "Продолжить";
        _changesText[10].text = "Звук";
        _changesText[11].text = "Музыка";
    }

    public void ChangeEng()
    {
        _changesText[0].text = "PLAY";
        _changesText[1].text = "SETTINGS";
        _changesText[2].text = "EXIT";
        _changesText[3].text = "   SETTINGS";
        _changesText[4].text = "SOUND";
        _changesText[5].text = "MUSIC";
        _changesText[6].text = "   LEVELS";
        _changesText[7].text = "RESUME";
        _changesText[8].text = "TO MENU";
        _changesText[9].text = "RESUME";
        _changesText[10].text = "SOUND";
        _changesText[11].text = "MUSIC";
    }
}