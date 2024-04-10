using UnityEngine;

public class Platform : MonoBehaviour
{
	public bool IsDestroy;
	public float jumpForce = 10f;

	private Animator _anim;

    private void Start()
    {
		_anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();

			if (rb != null)
			{				
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}

			if (IsDestroy & _anim != null)
			{
				Destroy(gameObject, 0.4f);
				_anim.SetTrigger("destroy");
			}
			else if (IsDestroy)
				Destroy(gameObject);
		}
	}
}
