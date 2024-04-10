using TMPro;
using UnityEngine;


namespace Scripts.Doodle
{
    public class DoodleScore : MonoBehaviour
    {
        [SerializeField] private GameObject _doodlePosition;

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private float _score;


        private void Update()
        {
            if (_doodlePosition.transform.position.y > _score)
            {
                AddScore(_doodlePosition.transform.position.y);
            }
        }

        public void ClearScore()
        {
            _score = 0;
            _scoreText.text = "0";
        }

        private void AddScore(float score)
        {
            _score = score;
            _scoreText.text = _score.ToString("0000");
        }
    }
}