using UnityEngine;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    public int _count;
    public int number;
    public string nameNumber;

    public void UpdateItem()
    {
        _count++;
        _countText.text = _count.ToString() + "x";
    }

    public void UpdateCount()
    {
        _countText.text = _count.ToString() + "x";
    }
}