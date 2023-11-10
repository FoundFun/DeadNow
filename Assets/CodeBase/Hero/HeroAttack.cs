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

        private const float DownSpeed = 0.1f;

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
            _attackSound.Play();
        
            _rigidbody2D.AddForce(Vector2.down * DownSpeed);
        
            yield return new WaitForSeconds(0.2f);
        
            IsAttack = true;

            yield return new WaitForSeconds(1);

            IsAttack = false;
        }
    }
}
