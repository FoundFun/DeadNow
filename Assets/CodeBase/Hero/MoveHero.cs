using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public HeroJump HeroJump;
        public float MovementSpeed;

        private Rigidbody2D _rigidbody2D;
        private HeroAnimator _heroAnimator;
        private Vector2 _moveDirection;
        private float _horizontal;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            Vector2 rigidbody = _rigidbody2D.velocity;

            if (rigidbody.x > 3)
            {
                rigidbody.x = 3;
                _rigidbody2D.velocity = rigidbody;
            }
            else if (rigidbody.x < -3)
            {
                rigidbody.x = -3;
                _rigidbody2D.velocity = rigidbody;
            }
        }

        private void FixedUpdate()
        {
            if (_horizontal != 0 && !HeroJump.IsJump)
                Move();
        }

        private void Move()
        {
            _heroAnimator.Move();
            _rigidbody2D.AddForce(new Vector2(_horizontal * MovementSpeed, _rigidbody2D.velocity.y), ForceMode2D.Force);
        }
    }
}