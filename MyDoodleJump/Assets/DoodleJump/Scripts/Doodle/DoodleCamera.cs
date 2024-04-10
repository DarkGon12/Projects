using UnityEngine;

public class DoodleCamera : MonoBehaviour
{
	public float smooth;
	public Transform target;

	void LateUpdate()
	{
		CameraFollowing();
	}

	private void CameraFollowing()
	{
		if (target.position.y > transform.position.y)
		{
			Vector3 newPos = Vector3.Lerp(transform.position, target.position, smooth * Time.smoothDeltaTime);
			transform.position = new Vector3(0, newPos.y, -10);
		}
	}
}