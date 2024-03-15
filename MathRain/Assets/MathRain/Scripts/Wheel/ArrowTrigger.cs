using UnityEngine;
using UnityEngine.UI;

public class ArrowTrigger : MonoBehaviour
{
    public NumberInventory inventory;
    public GameObject numberPrefabs;
    public Transform numberPanel;
    public Sprite[] _spriteNumber;

    [SerializeField]private string _nameNumber;

    public void CreateNumber()
    {
        inventory.numbers.RemoveAll(x => x == null);

        for (int i = 0; i < inventory.numbers.Count; i++)
        {
            if (inventory.numbers[i].name == _nameNumber)
            {
                inventory.AddDouble(_nameNumber);
                return;
            }
        }

        GameObject number = Instantiate(numberPrefabs, numberPanel);

        number.GetComponent<ItemInfo>().nameNumber = _nameNumber.ToString();
        number.GetComponent<ItemInfo>().number = int.Parse(_nameNumber);

        number.GetComponent<Image>().sprite = _spriteNumber[int.Parse(_nameNumber)];
        number.name = _nameNumber;
        inventory.numbers.Add(number);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _nameNumber = collision.name;
    }
}