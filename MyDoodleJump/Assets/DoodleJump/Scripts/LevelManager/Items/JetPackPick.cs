using UnityEngine;

namespace Scripts.LevelManager
{
    public class JetPackPick : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.tag == "Player")
            {
                JetPackProperty jet = collision.transform.GetChild(1).GetComponent<JetPackProperty>();
                jet.gameObject.SetActive(true);

                Destroy(gameObject);
            }
        }
    }
}