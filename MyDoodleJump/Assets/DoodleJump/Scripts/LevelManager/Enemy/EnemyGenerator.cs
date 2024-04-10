using Scripts.ResourceManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.LevelManager
{
    class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyList = new List<GameObject>();

        private Vector2 _spawnPosition = new Vector2();
        private Transform _cameraPosition;
        private float _enemyUpdate = 130;

        private void Start()
        {
            GenerateEnemys();

            _cameraPosition = Camera.main.transform;
        }

        private void Update()
        {
            RegenerateLevel();
        }

        private void RegenerateLevel()
        {
            if (_cameraPosition.position.y >= _enemyUpdate)
            {
                _enemyUpdate += 130;
                GenerateEnemys();
            }
        }

        public void ClearCash()
        {
            _spawnPosition = Vector3.zero;
            StartCoroutine(RemoveAllEnemy(0));
        }

        public void RemoveEnemy(GameObject go)
        {
            Destroy(go);
            _enemyList.Remove(go);
            _enemyList.RemoveAll(x => x == null);
        }

        private IEnumerator RemoveAllEnemy(float t)
        {
            for (int i = 0; i < _enemyList.Count; i++)
            {
                Destroy(_enemyList[i], t);
            }

            yield return new WaitForSeconds(t);

            _enemyList.RemoveAll(x => x == null);

            StopAllCoroutines();
            yield return null;
        }

        public void GenerateEnemys()
        {
            int enemyCountOnLevel = Random.Range(10, 14);

            for (int i = 0; i < enemyCountOnLevel; i++)
            {
                int randomEnemy = Random.Range(0, 100);

                if (randomEnemy <= 33)
                    CreateEnemy(EnemyType.idleEnemy);
                if (randomEnemy > 33 & randomEnemy <= 66)
                    CreateEnemy(EnemyType.transformEnemy);
                if (randomEnemy > 66 & randomEnemy <= 100)
                    CreateEnemy(EnemyType.blackSpace);
            }
        }
        
        private void CreateEnemy(EnemyType type)
        {
            _spawnPosition.y += Random.Range(10, 25f);
            _spawnPosition.x = Random.Range(-2.5f, 2.5f);

            GameObject enemy = ResourceSimplificator.Instantiate(type.ToString(), _spawnPosition) as GameObject;
            _enemyList.Add(enemy);
        }
    }
}