using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Scripts.ResourceManager;
using NaughtyAttributes;
using UnityEngine;
using System;

namespace Scripts.LevelManager
{
    public class PlatformGenerator : MonoBehaviour
    {
        [InfoBox("Кол-во платформ на экране")]
        [SerializeField] private int _numberOfPlatforms = 200;
        [InfoBox("Диапозон ширины в котором генерируются платформы")]
        [SerializeField] private float _levelWidth = 3f;

        private List<GameObject> _platforms = new List<GameObject>();

        private Transform _cameraPosition;
        private Vector3 _spawnPosition;
        private float _platformUpdate = 120;
        
        private float _minY;
        private float _maxY;

        private void Start()
        {
            _cameraPosition = Camera.main.transform;
            StartGeneratePlatforms();
        }

        private void Update()
        {
            RegenerateLevel();
        }

        private void RegenerateLevel()
        {
            if (_cameraPosition.position.y >= _platformUpdate)
            {
                _platformUpdate += 120;
                StartGeneratePlatforms();
            }
        }

        public void RemovePlatform(GameObject go)
        {
            Destroy(go);
            _platforms.Remove(go);
            _platforms.RemoveAll(x => x == null);
        }

        public async void RemoveAllPlatform()
        {
            _spawnPosition = Vector3.zero;
            _platformUpdate = 120;

            _minY = 0.5f;
            _maxY = 0.5f;

            await PlatformsDestroy(0);
        }

        private async UniTask PlatformsDestroy(float t)
        {
            for (int i = 0; i < _platforms.Count; i++)
                Destroy(_platforms[i], t);

            await UniTask.Delay(TimeSpan.FromSeconds(t));
            _platforms.RemoveAll(x => x == null);   
        }

        public void StartGeneratePlatforms()
        {
            if (_maxY < 2.2f)
            {
                _minY += 0.5f;
                _maxY += 0.5f;
            }

            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                int randomyze = UnityEngine.Random.Range(0, 100);

                if (randomyze <= 50)
                    GeneratePlatforms(PlatformType.Standart_Platform);
                if (randomyze > 50 & randomyze <= 60)
                    GeneratePlatforms(PlatformType.MoveUp_Platform);
                if (randomyze > 60 & randomyze <= 70)
                    GeneratePlatforms(PlatformType.MoveHorizontal_Platform);
                if (randomyze > 70 & randomyze <= 80)
                    GeneratePlatforms(PlatformType.Hide_Platform);
                if (randomyze > 80 & randomyze <= 90)
                    GeneratePlatforms(PlatformType.RedDestroy_Platform);
                if (randomyze > 90 & randomyze <= 100)
                    GeneratePlatforms(PlatformType.Destroy_Platform);
            }
        }

        private void GeneratePlatforms(PlatformType types)
        {
            if (types != PlatformType.Destroy_Platform)
                _spawnPosition.y += UnityEngine.Random.Range(_minY, _maxY);

            _spawnPosition.x = UnityEngine.Random.Range(-_levelWidth, _levelWidth);

            GameObject platform = ResourceSimplificator.Instantiate(types.ToString(), _spawnPosition) as GameObject;
            AddPlatformDictionary(platform);
        }

        private void AddPlatformDictionary(GameObject platform) => _platforms.Add(platform);
    }
}