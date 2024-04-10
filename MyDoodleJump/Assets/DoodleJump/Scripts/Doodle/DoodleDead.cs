using Scripts.LevelManager;
using UnityEngine;

namespace Scripts.Doodle
{
    public class DoodleDead : MonoBehaviour
    {
        [SerializeField] private Canvas _deadPanel;
        [SerializeField] private PlatformGenerator _level;
        [SerializeField] private EnemyGenerator _enemy;
        [SerializeField] private DoodleMove _doodleMove;

        [SerializeField] private GameObject _jet, _shield;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Dead(collision);

            DestroyPlatform(collision);
        }

        private void DestroyPlatform(Collider2D collision)
        {
            if (collision.transform.tag == "platform")
            {
                _level.RemovePlatform(collision.gameObject);
                _enemy.RemoveEnemy(collision.gameObject);
            }
        }

        public void Dead(Collider2D collision)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (collision.transform.tag == "Player")
            {
                _deadPanel.enabled = true;
                rb.velocity = Vector2.zero;
                _doodleMove.enabled = false;
                _jet.SetActive(false);
                _shield.SetActive(false);
            }
        }
    }
}