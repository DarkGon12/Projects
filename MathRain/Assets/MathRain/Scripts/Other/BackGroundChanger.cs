using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> allFone = new List<Sprite>();
    [SerializeField] private float _changeTime;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BackGroundCoroutine());
    }

    private IEnumerator BackGroundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_changeTime, _changeTime + 2f));
            yield return StartCoroutine(FadeOut());
            ChangeBackground();
            yield return StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeOut()
    {
        while (_spriteRenderer.color.a > 0.1f)
        {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, new Color(1, 1, 1, 0), 8 * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeIn()
    {
        while (_spriteRenderer.color.a < 0.99f)
        {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, new Color(1, 1, 1, 1), 8 * Time.deltaTime);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void ChangeBackground() =>
        _spriteRenderer.sprite = allFone[Random.Range(0, allFone.Count)];
}