using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class DragCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform _uiParent;

    private Sprite _emptySprite;
    private Sprite _originalSprite;
    private CanvasGroup _canvasGroup;

    private GameObject _numberPrefab;
    private GameObject _curentDragObject;

    private PuzzleRow _puzzleRow;
    private CellDetail _cellDetails;

    private void Start()
    {
        InitializeCell();
    }

    private void InitializeCell()
    {
        _uiParent = GameObject.FindGameObjectWithTag("dragDropInterface").transform;

        _numberPrefab = Resources.Load<GameObject>("Prefabs/Number");
        _emptySprite = Resources.Load<Sprite>("Sprites/EmptyCell");

        _cellDetails = GetComponent<CellDetail>();
        _puzzleRow = GetComponentInParent<PuzzleRow>();
    }

    private bool CanDrag()
    {
        return _puzzleRow.IsSolved | transform.name == "x" | _cellDetails.number == "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CanDrag())
            return;

        transform.name = "x";

        CreateDragObject();
        ConfigureDragObject();
        UpdateCellAppearance();    
    }

    private void UpdateCellAppearance()
    {
        _originalSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = _emptySprite;
    }

    private void CreateDragObject()
    {
        _curentDragObject = Instantiate(_numberPrefab, _uiParent);
        _curentDragObject.transform.localScale = new Vector3(1f, 1f, 1f);
        _curentDragObject.name = _cellDetails.number;  
    }

    private void ConfigureDragObject()
    {
        _curentDragObject.GetComponent<ItemInfo>().nameNumber = _cellDetails.number;
        _curentDragObject.GetComponent<ItemInfo>().number = int.Parse(_cellDetails.number);
        _curentDragObject.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;

        _canvasGroup = _curentDragObject.GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_puzzleRow.IsSolved)
            return;
        if (_cellDetails.number == "")
            return;

        _curentDragObject.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_curentDragObject != null)
            Destroy(_curentDragObject);

        if (_puzzleRow.IsSolved)
            return;
        if (_cellDetails.number == "")
            return;

        GetComponent<SpriteRenderer>().sprite = _originalSprite;
        transform.name = _cellDetails.number;
    }
}