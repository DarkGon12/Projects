using Scripts.LevelManager;
using UnityEngine;

namespace Scripts.Doodle
{
    class DoodleRestart : MonoBehaviour
    {
        [SerializeField] private GameObject _doodlePosition, _cameraPosition;
        [SerializeField] private GameObject _doodleRocketItem, _doodleShieldItem;
        [SerializeField] private PlatformGenerator _levelGenerator;
        [SerializeField] private EnemyGenerator _enemyGenerator;
        [SerializeField] private ItemGenerator _itemGenerator;
        [SerializeField] private DoodleScore _score;
        [SerializeField] private DoodleMove _doodleMove;
        [SerializeField] private Rigidbody2D _doodleRigidBody;

        public void RestartGame()
        {
            _score.ClearScore();

            _levelGenerator.RemoveAllPlatform();
            _levelGenerator.StartGeneratePlatforms();

            _enemyGenerator.ClearCash();
            _enemyGenerator.GenerateEnemys();

            _itemGenerator.ClearCash();
            _itemGenerator.GenerateItems();

            _doodleRocketItem.SetActive(false);
            _doodleShieldItem.SetActive(false);

            _doodleRigidBody.isKinematic = false;

            _doodlePosition.transform.position = new Vector3(0, -1, 0);
            _cameraPosition.transform.position = new Vector3(0, 0, -10);

            _doodleMove.enabled = true;
        }
    }
}
