using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberInventory : MonoBehaviour
{
    [Header("ForCreate Parametrs")]
    public GameObject numberPrefabs;
    public Transform numberPanel;
    public Sprite[] _spriteNumber;
    [Header("Created numbers")]
    public List<GameObject> numbers = new List<GameObject>();

    public void AddDouble(string item)
    {
        for(int i = 0; i < numbers.Count; i++)
        {
            if(numbers[i].name == item)
            {
                numbers[i].GetComponent<ItemInfo>().UpdateItem();
                break;
            }
        }
    }

    public void CreateNumber(CellDetail createNumber)
    {
        numbers.RemoveAll(x => x == null);

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i].name == createNumber.number)
            {
                AddDouble(createNumber.number);
                return;
            }
        }

        GameObject number = Instantiate(numberPrefabs, numberPanel);
        number.name = createNumber.number;

        number.GetComponent<ItemInfo>().nameNumber = createNumber.number;
        number.GetComponent<ItemInfo>().number = int.Parse(createNumber.number);

        number.GetComponent<Image>().sprite = _spriteNumber[int.Parse(createNumber.number)];

        numbers.Add(number);
    }
}