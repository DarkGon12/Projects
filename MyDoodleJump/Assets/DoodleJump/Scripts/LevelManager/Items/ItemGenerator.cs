using Scripts.ResourceManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.LevelManager
{
    class ItemGenerator : MonoBehaviour
    {
        private List<GameObject> _itemList = new List<GameObject>();

        private Vector2 _spawnPosition = new Vector2();
        private Transform _cameraPosition;
        private float _itemUpdate = 130;

        private void Start()
        {
            GenerateItems();
            _cameraPosition = Camera.main.transform;
        }

        private void Update()
        {
            RegenerateLevel();
        }

        private void RegenerateLevel()
        {
            if (_cameraPosition.position.y >= _itemUpdate)
            {
                _itemUpdate += 130;
                GenerateItems();
            }
        }

        public void ClearCash()
        {
            _spawnPosition = Vector3.zero;
            StartCoroutine(RemoveAllItem(0));
        }

        private IEnumerator RemoveAllItem(float t)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                Destroy(_itemList[i], t);
            }

            yield return new WaitForSeconds(t);

            _itemList.RemoveAll(x => x == null);

            StopAllCoroutines();
            yield return null;
        }

        public void RemoveItem(GameObject go)
        {
            Destroy(go);
            _itemList.Remove(go);
            _itemList.RemoveAll(x => x == null);
        }

        public void GenerateItems()
        {
            int itemCountOnLevel = Random.Range(2, 4);

            for (int i = 0; i < itemCountOnLevel; i++)
            {
                int randomItem = Random.Range(0, 100);

                if (randomItem <= 33)
                    CreateItem(ItemTypes.jet);
                if (randomItem > 33 & randomItem <= 66)
                    CreateItem(ItemTypes.jumper);
                if (randomItem > 66 & randomItem <= 100)
                    CreateItem(ItemTypes.shield);
            }
        }

        private void CreateItem(ItemTypes type)
        {
            _spawnPosition.y += Random.Range(10, 45f);
            _spawnPosition.x = Random.Range(-2.5f, 2.5f);

            GameObject enemy = ResourceSimplificator.Instantiate(type.ToString(), _spawnPosition) as GameObject;
            _itemList.Add(enemy);
        }
    }
}