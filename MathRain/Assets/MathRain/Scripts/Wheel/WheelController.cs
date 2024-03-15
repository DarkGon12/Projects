using System.Collections;
using UnityEngine;
using TMPro;

public class WheelController : MonoBehaviour
{
    [SerializeField] private Sprite _piarSprite, _standartSprite;
    [SerializeField] private SpriteRenderer _wheelCenter;

    public ArrowTrigger aTrigger;

    public Transform wheel;
    public float wheelCount;
    public float wheelSpeed;
    public GameObject interfaceForNumbers;
    public TextMeshProUGUI wheelCountUI;

    public bool isWheelStart;

    private void Start()
    {
        wheelCount = 60;
    }

    public void WheelRotate()
    {
        if (!isWheelStart)
        {
            if (wheelCount <= 0)
            {
                _wheelCenter.sprite = _piarSprite;
                wheelCountUI.text = "";
                return;
            }

            _wheelCenter.sprite = _standartSprite;

            wheelCount--;
            wheelCountUI.text = wheelCount.ToString();
            isWheelStart = true;

            StopAllCoroutines();
            StartCoroutine(WheelControllers());
        }
    }

    private void Update()
    {
        if(isWheelStart)
        {
            wheel.Rotate(new Vector3(0,0,1 * wheelSpeed));
        }
    }

    private IEnumerator WheelControllers()
    {
        while(wheelSpeed < 2.5f)
        {
            wheelSpeed += Random.Range(0.6f, 0.95f);
            yield return new WaitForSeconds(0.1f);
        }
        while (wheelSpeed > 0.0000000f)
        {
            if (wheelSpeed > 0.000001f)
            {
                if(wheelSpeed > 0.5f)
                {
                    yield return new WaitForSeconds(0.1f);
                    wheelSpeed -= Random.Range(0.27f, 0.35f);
                }
                else
                {
                    yield return new WaitForSeconds(0.6f);
                    wheelSpeed -= Random.Range(0.02f, 0.04f);
                }
            }
            else
            {
                wheelSpeed = 0f;
                isWheelStart = false;
                aTrigger.CreateNumber();
                yield return null;
                StopAllCoroutines();
            }
        }

        wheelSpeed = 0f;
        isWheelStart = false;
        aTrigger.CreateNumber();
        yield return null;
        StopAllCoroutines();
    }

}