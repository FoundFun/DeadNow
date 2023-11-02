using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private const float MaxVelocityX = 5;
        private const float MinVelocityX = -5;

        private HeroInput _input;
        private Rigidbody2D _rigidbody2D;
        private HeroAnimator _heroAnimator;
        private Vector2 _direction;

        private void Awake()
        {
            _input = new HeroInput();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void OnEnable() => 
            _input.Enable();

        private void OnDisable() => 
            _input.Disable();

        private void Update() => 
            _direction = _input.Hero.Move.ReadValue<Vector2>();

        private void FixedUpdate()
        {
            if (_direction.x != 0 && WithinVelocity())
                Move();
        }

        private bool WithinVelocity() => 
            _rigidbody2D.velocity.x is < MaxVelocityX and > MinVelocityX;

        private void Move()
        {
            _heroAnimator.Move();
            _rigidbody2D.AddForce(Vector2.right * _direction.x * _speed, ForceMode2D.Force);
        }
    }
}