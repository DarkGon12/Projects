using UnityEngine;

public class CellDetail : MonoBehaviour
{
    public string number;
    public Sprite numberSprite;
    public Sprite nullCell;

    private void Start()
    {
        nullCell = GetComponent<SpriteRenderer>().sprite;
    }

    public void ResetCell()
    {
        number = null;
        numberSprite = null;
    }
}