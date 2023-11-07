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
        
        public bool IsTransfer { get; private set; }

        private WaitForSeconds _coroutineWait = new WaitForSeconds(2);

        private const float _downSpeed = 0.1f;

        private void Awake()
        {
            _input = new HeroInput();
            _animator = GetComponent<HeroAnimator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _input.Hero.Squat.performed += (_) => StartCoroutine(Transfer());
        }

        private void OnEnable() =>
            _input.Enable();

        private void OnDisable() =>
            _input.Disable();

        private IEnumerator Transfer()
        {
            if (!IsTransfer)
                yield break;

            IsTransfer = true;
            _animator.SitDown();
            _rigidbody2D.AddForce(Vector2.down * _downSpeed);

            yield return _coroutineWait;

            IsTransfer = false;
        }
    }
}
