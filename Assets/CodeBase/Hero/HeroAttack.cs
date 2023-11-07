using System.Collections;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(Rigidbody2D), typeof(AudioSource))]
    public class HeroAttack : MonoBehaviour
    {
        private HeroInput _input;
        private HeroAnimator _animator;
        private Rigidbody2D _rigidbody2D;
        private AudioSource _attackSound;

        private const float _downSpeed = 0.1f;

        private bool _delay;
    
        public bool IsAttack { get; private set; }

        private void Awake()
        {
            _input = new HeroInput();
            _animator = GetComponent<HeroAnimator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _attackSound = GetComponent<AudioSource>();

            _input.Hero.Attack.performed += (_) => StartCoroutine(Attack());
        }

        private void OnEnable() =>
            _input.Enable();

        private void OnDisable() =>
            _input.Disable();

        private IEnumerator Attack()
        {
            _animator.PlayAttack();
        
            _rigidbody2D.AddForce(Vector2.down * _downSpeed);
        
            yield return new WaitForSeconds(0.2f);
        
            IsAttack = true;

            yield return new WaitForSeconds(1);

            _delay = false;
            IsAttack = false;
        }
    }
}
