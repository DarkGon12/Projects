using System.Collections.Generic;
using UnityEngine;

public class GroupPuzzle : MonoBehaviour
{
    public List<bool> IsSolvedPuzzle { get; private set; } = new List<bool>();

    [SerializeField] private List<PuzzleRow> _puzzlesRow = new List<PuzzleRow>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            IsSolvedPuzzle.Add(false);
        }
    }

    public void RestartGroup()
    {
        for (int i = 0; i < _puzzlesRow.Count; i++)
        {
            _puzzlesRow[i].Restart();
        }
    }
}
