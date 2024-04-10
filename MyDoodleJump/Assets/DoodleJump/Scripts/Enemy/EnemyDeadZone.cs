using Scripts.Doodle;
using Scripts.LevelManager.Items;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyDeadZone : MonoBehaviour
    {
        private DoodleDead _doodleZone;
        private ShieldProperty _shield;

        private void Start()
        {
            _doodleZone = FindObjectOfType<DoodleDead>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                _shield = FindObjectOfType<ShieldProperty>();

                if (_shield != null)
                {
                    if (!_shield.IsShield)
                        _doodleZone.Dead(collision);
                }
                else
                    _doodleZone.Dead(collision);
            }
        }
    }
}