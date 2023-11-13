using CodeBase.Services;
using CodeBase.Services.Input;
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

        private Rigidbody2D _rigidbody2D;
        private HeroAnimator _heroAnimator;
        private IInputService _inputService;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _heroAnimator = GetComponent<HeroAnimator>();
            
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update() => 
            _direction = _inputService.Axis;

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