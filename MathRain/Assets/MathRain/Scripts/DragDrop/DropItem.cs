using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioSource _dropSound;

    private PuzzleRow _puzzleRow;
    private SpriteRenderer _dropSpriteRenderer;
    private CellDetail _cellDetail;

    private void Start()
    {
        _dropSpriteRenderer = GetComponent<SpriteRenderer>();
        _cellDetail = GetComponent<CellDetail>();
        _puzzleRow = GetComponentInParent<PuzzleRow>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_cellDetail && string.IsNullOrEmpty(_cellDetail.number))
        {
            var draggedItem = eventData.pointerDrag;
            if (draggedItem != null)
            {
                ProcessDraggedItem(draggedItem);
            }
        }
    }

    private void ProcessDraggedItem(GameObject draggedItem)
    {
        var itemImage = draggedItem.GetComponent<Image>();
        var itemInfo = draggedItem.GetComponent<ItemInfo>();
        var cellDetailSource = draggedItem.GetComponent<CellDetail>();

        if (itemImage && itemInfo)
        {
            UpdateCellFromDraggedItem(itemImage, itemInfo);
        }
        else if (cellDetailSource)
        {
            UpdateCellFromDraggedCell(cellDetailSource);
        }

        _dropSound.Play();
    }

    private void UpdateCellFromDraggedItem(Image itemImage, ItemInfo itemInfo)
    {
        _dropSpriteRenderer.sprite = itemImage.sprite;
        _cellDetail.number = itemInfo.transform.name;
        _cellDetail.numberSprite = itemImage.sprite;
        transform.name = itemInfo.transform.name;

        itemInfo._count--;
        itemInfo.UpdateCount();

        if (itemInfo._count <= 0)
        {
            Destroy(itemInfo.gameObject);
        }

        UpdatePuzzleRow();
    }

    private void UpdateCellFromDraggedCell(CellDetail sourceCellDetail)
    {
        _dropSpriteRenderer.sprite = sourceCellDetail.numberSprite;
        _cellDetail.number = sourceCellDetail.number;
        _cellDetail.numberSprite = sourceCellDetail.numberSprite;
        transform.name = sourceCellDetail.number;

        sourceCellDetail.ResetCell();

        UpdatePuzzleRow();
    }

    private void UpdatePuzzleRow()
    {
        _puzzleRow.EquationBuild.BuildEquation();
        _puzzleRow.CalculateResult();
    }
}