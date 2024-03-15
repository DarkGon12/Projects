using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private List<GameObject> _puzzles = new List<GameObject>();

    public void Next()
    {
        StopAllCoroutines();
        StartCoroutine(NextLevelState());
    }

    private IEnumerator NextLevelState()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < _puzzles.Count; i++)
        {
            if (_puzzles[i].activeSelf)
            {
                if (i + 1 != _puzzles.Count)
                {
                    _puzzles[i].SetActive(false);
                    _puzzles[i + 1].SetActive(true);
                    _saveManager.Save(i + 2);  // ------------------- SAVE ------------------- 
                    break;
                }
            }
        }
        yield return null;
    }
}