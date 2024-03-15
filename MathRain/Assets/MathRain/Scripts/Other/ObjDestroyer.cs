using UnityEngine;

public class ObjDestroyer : MonoBehaviour
{

    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
