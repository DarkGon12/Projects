using UnityEngine.EventSystems;
using UnityEngine;

namespace Scripts.Doodle
{
    public class DoodleButtonMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private DoodleMove _doodleMove;
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _horizontalSpeed;

        [SerializeField] private bool _isLeft;
        private bool _move;

        private void Start()
        {
            if (_doodleMove.IsButtonMove)
                _doodleMove.InputService = null;
        }

        public void OnPointerDown(PointerEventData eventData) =>
            _move = true;

        private void FixedUpdate()
        {
            if (!_move)
                return;

            Vector2 _direction = _rigidBody.velocity;
            if (_isLeft)
                _direction.x = -1 * _horizontalSpeed * Time.fixedDeltaTime;
            else
                _direction.x = 1 * _horizontalSpeed * Time.fixedDeltaTime;

            _doodleMove.Move(_direction);
        }

        public void OnPointerUp(PointerEventData eventData) =>
            _move = false;
    }
}