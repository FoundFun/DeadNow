using System.Collections;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(Rigidbody2D))]
    public class HeroSquat : MonoBehaviour
    {
        private HeroAnimator _animator;
        private Rigidbody2D _rigidbody2D;
        private HeroInput _input;

        private const float _downSpeed = 0.1f;
    
        public bool IsTransfer { get; private set; }

        private void Awake()
        {
            _input = new HeroInput();
            _animator = GetComponent<HeroAnimator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && !IsTransfer)
            {
                IsTransfer = true;
                StartCoroutine(Transfer());
            }
        }

        private IEnumerator Transfer()
        {
            _animator.SitDown();
            _rigidbody2D.AddForce(Vector2.down * _downSpeed);

            yield return new WaitForSeconds(2);

            IsTransfer = false;
        }
    }
}
