using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroMove : MonoBehaviour
    {
        private const float MoveSpeed = 4;

        private Rigidbody2D _rigidbody2D;
        private HeroAnimator _heroAnimator;
        private float _direction;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update() => 
            _direction = Input.GetAxis("Horizontal");

        private void FixedUpdate()
        {
            if (_direction != 0)
                Move();
        }

        private void Move()
        {
            _heroAnimator.Move();
            _rigidbody2D.MovePosition(new Vector2(_rigidbody2D.transform.position.x + _direction * Speed(),
                _rigidbody2D.transform.position.y));
        }

        private float Speed() => 
            MoveSpeed * Time.fixedDeltaTime;
    }
}