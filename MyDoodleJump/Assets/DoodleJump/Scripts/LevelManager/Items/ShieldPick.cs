using UnityEngine;

namespace Scripts.LevelManager.Items
{
    public partial class ShieldPick : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                ShieldProperty shield = collision.transform.GetChild(0).GetComponent<ShieldProperty>();
                shield.gameObject.SetActive(true);

                shield.StartShield();

                Destroy(gameObject);
            }
        }
    }
}