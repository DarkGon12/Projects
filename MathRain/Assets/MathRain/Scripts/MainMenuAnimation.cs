using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetMove_1, _targetMove_2;
    [SerializeField] private Vector3 _moveDown, _moveRight;
    [SerializeField] private float _moveSpeed;

    private Vector3 _startPos_1, _startPos_2;

    private void Start()
    {
        _startPos_1 = _targetMove_1.localPosition;
        _startPos_2 = _targetMove_2.localPosition;
    }

    public void OpenWindow(GameObject closeWindow)
    {
        StartCoroutine(WaitAndOpenWindow(closeWindow));
    }

    public void ResetTransformWindow()
    {
        _targetMove_1.DOLocalMove(_startPos_1, 1.5f);
        _targetMove_2.DOLocalMove(_startPos_2, 1.5f);
    }

    private IEnumerator WaitAndOpenWindow(GameObject window)
    {
        while (true)
        {
            _targetMove_1.DOMove(_moveDown, _moveSpeed, true);
            _targetMove_2.DOMove(_moveRight, _moveSpeed, true);
            yield return new WaitForSeconds(1f);
            window.SetActive(false);
            yield return null;
            StopAllCoroutines();
        }
    }
}