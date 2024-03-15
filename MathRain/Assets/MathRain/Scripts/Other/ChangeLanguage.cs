using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _changesText;

    public void ChangeRus()
    {
        _changesText[0].text = "������";
        _changesText[1].text = "���������";
        _changesText[2].text = "�����";
        _changesText[3].text = "   ���������";
        _changesText[4].text = "����";
        _changesText[5].text = "������";
        _changesText[6].text = "   ������";
        _changesText[7].text = "����������";
        _changesText[8].text = "� ����";
        _changesText[9].text = "����������";
        _changesText[10].text = "����";
        _changesText[11].text = "������";
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