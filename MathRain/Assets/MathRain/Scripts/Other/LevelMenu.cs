using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    [SerializeField] private GameObject _mainMenu, _levelsPanel;

    private int currentActiveLevel = -1; // -1 означает, что ни один уровень не активен

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < _levels.Count) 
        {
            if (currentActiveLevel != -1)
            {
                _levels[currentActiveLevel].SetActive(false); 
            }

            _levels[levelIndex].SetActive(true);
            currentActiveLevel = levelIndex;

            _mainMenu.SetActive(false);
            _levelsPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("LoadLevel was called with an invalid level index.");
        }
    }
}
