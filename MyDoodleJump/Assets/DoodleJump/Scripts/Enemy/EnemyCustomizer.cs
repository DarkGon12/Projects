using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyCustomizer : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            
            int rand = Random.Range(0, 5);
            _sprite.sprite = Resources.Load<Sprite>("Sprites/Enemy/" + rand.ToString());
        }
    }
}