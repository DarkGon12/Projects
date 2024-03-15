using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private List<Button> _levelButtons = new List<Button>();

    private int _saveLevel;

    private void Awake()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        _saveLevel = PlayerPrefs.GetInt("SaveLevel");
        for(int i = 0; i < _saveLevel; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }

    private void SaveLevel(int level) // ��������� ������� ������ ��� ����� �� ������������ � �������� �� ����� ��� �� �� ���������� �������� ������ ( �� ����� ������������, ����� ������ ���� )
    {
        PlayerPrefs.SetInt("SaveLevel", level);

        for (int i = 0; i < level; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }

    public void Save(int current)
    {
        SaveLevel(current);
    }
}