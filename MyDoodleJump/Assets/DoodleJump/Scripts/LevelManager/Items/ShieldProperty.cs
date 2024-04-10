using System.Collections;
using UnityEngine;

namespace Scripts.LevelManager.Items
{
    public class ShieldProperty : MonoBehaviour
    {
        [SerializeField] private float _shieldTime;
        [SerializeField] private float _times;

        public bool IsShield;

        public void StartShield()
        {
            _times = _shieldTime;

            IsShield = true;

            StopAllCoroutines();
            StartCoroutine(ShieldProcces());
        }

        private IEnumerator ShieldProcces()
        {
            while (true)
            {
                _times--;

                yield return new WaitForSeconds(0.03f);

                if (_times <= 0)
                {
                    IsShield = false;
                    gameObject.SetActive(false);
                    StopAllCoroutines();
                    yield return null;
                }
            }
        }
    }
}