using System.Collections;
using UnityEngine;

namespace Scripts.LevelManager
{
    public class JetPackProperty : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private DoodleCamera _camera;
        [Space(20)]
        [SerializeField] private float _flyTime, _jetPower;
        [SerializeField] private float _times;

        public void StartJet()
        {
            _times = _flyTime;
            _camera.smooth = 999;

            StopAllCoroutines();
            StartCoroutine(JetProcces());
        }

        private IEnumerator JetProcces()
        {
            while (true)
            {
                JetPower();
                _times--;

                yield return new WaitForSeconds(0.03f);

                if (_times <= 0)
                {
                    _rigidBody.isKinematic = false;
                    gameObject.SetActive(false);
                    _camera.smooth = 1f;
                    StopAllCoroutines();
                    yield return null;
                }
            }
        }

        private void JetPower()
        {
            Vector2 velocity = _rigidBody.velocity;
            velocity.y = _jetPower;
            _rigidBody.velocity = velocity;
        }
    }
}