using UnityEngine;
using UnityEngine.EventSystems;

public class DropCell : MonoBehaviour, IDropHandler
{
    private NumberInventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<NumberInventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<CellDetail>())
        {
            _inventory.CreateNumber(eventData.pointerDrag.GetComponent<CellDetail>());

            eventData.pointerDrag.GetComponent<SpriteRenderer>().sprite = eventData.pointerDrag.GetComponent<CellDetail>().nullCell;
            eventData.pointerDrag.GetComponent<CellDetail>().number = "";
            eventData.pointerDrag.GetComponent<CellDetail>().numberSprite = null;
        }
    }
}