using Scripts.Boostraper;
using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Doodle
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DoodleMove : MonoBehaviour
    {
        public IInputService InputService;
        public bool IsButtonMove;

        private SpriteRenderer _spriteBody, _rocket;
        private Rigidbody2D _rigidBody;
        private BoxCollider2D _boxCollider;

        [Header("Скорость")]
        [Tooltip("Максимальная скорость движения")] [SerializeField] private float _horizontalSpeed;
        [Tooltip("Максимальная скорость движения")] [SerializeField] private float _maxMoveSpeed;
        [Tooltip("Работает только в редакторе, авто-остановка при движении")] [SerializeField] private float _horizontalSpeedLerp;
        [Space(15)]
        [Tooltip("Будет ли отталкиваться от платформы если уже летит вверх")] [SerializeField] private bool _IsUpper = true;

        private void Start()
        {
            InputService = ServiceInitialiazatior.InputService;
            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteBody = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();

            _rocket = transform.GetChild(1).GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if(!IsButtonMove)
                InputMove();

            RigidBodyClamp();
            RigidBodyLerp();

            GameBox();

            if (_IsUpper)
                CollisionCaretake();
        }

        private void GameBox()
        {
            if (transform.position.x > 3.1f)
                transform.position = new Vector2(-2.8f, transform.position.y);
            if (transform.position.x < -2.8f)
                transform.position = new Vector2(3.1f, transform.position.y);
        }

        private void CollisionCaretake()
        {
            if (_rigidBody.velocity.y > 0f)
                _boxCollider.isTrigger = true;
            else
                _boxCollider.isTrigger = false;
        }

        public void Move(Vector2 direction)
        {
            _rigidBody.velocity = direction;
            Flip(direction);
        }

        private void InputMove()
        {
            Vector2 _direction = _rigidBody.velocity;
            _direction.x = InputService.Axis.x * _horizontalSpeed * Time.fixedDeltaTime;
            Move(_direction);
        }

        private void RigidBodyLerp()
        {
            float StopPower = _horizontalSpeed * Time.fixedDeltaTime * _horizontalSpeedLerp * -Mathf.Sign(_rigidBody.velocity.x);

            if (InputService.Axis == Vector2.zero)
            {
                if (Mathf.Abs(StopPower) < Mathf.Abs(_rigidBody.velocity.x))
                {
                    _rigidBody.velocity += new Vector2(StopPower, 0);
                }
                else
                {
                    _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
                }
            }
        }

        private void RigidBodyClamp()
        {
            if (_rigidBody.velocity.magnitude > _maxMoveSpeed)
                _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _maxMoveSpeed);
        }

        private void Flip(Vector2 direction)
        {
            if (direction.x >= 0)
            {
                _spriteBody.flipX = false;
                _rocket.flipX = false;
                _rocket.transform.localPosition = new Vector2(-0.36f, -0.23f);
            }
            else
            {
                _spriteBody.flipX = true;
                _rocket.flipX = true;
                _rocket.transform.localPosition = new Vector2(0.36f, -0.23f);
            }
        }
    }
}