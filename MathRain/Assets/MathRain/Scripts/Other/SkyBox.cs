using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(new Vector2(1 * speed * Time.deltaTime, 0));

        if(transform.position.x > 4.10f)
        {
            transform.position = new Vector2(-3.5f, Random.Range(0, 5f));
            speed = Random.Range(0.1f,0.2f);
        }
    }
}