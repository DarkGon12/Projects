using System.Collections;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    [SerializeField] private Color _redColor;

    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnBecameVisible()
    {
        if (_sprite != null)
            StartDestroy();
    }

    public void StartDestroy()
    {
        StartCoroutine(StartDestroyPlatform());
    }

    private IEnumerator StartDestroyPlatform()
    {
        while (true)
        {
            _sprite.color = Color.Lerp(_sprite.color, _redColor, 0.1f);
            yield return new WaitForSeconds(0.1f);

            if (_sprite.color == _redColor)
            {
                Destroy(gameObject);
                yield return null;
            }
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}