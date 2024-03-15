using UnityEngine.EventSystems;
using UnityEngine;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rTransform;
    private Transform parentObject;
    private CanvasGroup _cGroup;

    private void Start()
    {
        _rTransform = GetComponent<RectTransform>();
        _cGroup = GetComponent<CanvasGroup>();
        parentObject = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.transform.SetParent(transform.parent.parent.parent.parent);
        _cGroup.blocksRaycasts = false;
        _rTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rTransform.transform.position = new Vector2(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x, Camera.main.ScreenPointToRay(Input.mousePosition).origin.y + 0.03f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _cGroup.blocksRaycasts = true;
        gameObject.transform.SetParent(parentObject);
        _rTransform.localScale = new Vector3(1,1,1);
    }
}