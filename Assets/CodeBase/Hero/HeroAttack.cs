using System.Collections;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(Rigidbody2D),
        typeof(AudioSource))]
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private AudioClip _attack;

        private HeroInput _input;
        private HeroAnimator _animator;
        private Rigidbody2D _rigidbody2D;
        private AudioSource _audioSource;

        private const float DownSpeed = 0.1f;

        public bool IsAttack { get; private set; }

        private void Awake()
        {
            _input = new HeroInput();
            _animator = GetComponent<HeroAnimator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();

            _input.Hero.Attack.performed += (_) => StartCoroutine(Attack());
        }

        private void OnEnable()
        {
            _input.Enable();
            EventBus.Instance.HeroAttack += () => StartCoroutine(Attack());
        }

        private void OnDisable()
        {
            _input.Disable();
            EventBus.Instance.HeroAttack -= () => StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            _animator.PlayAttack();
            _audioSource.PlayOneShot(_attack);

            _rigidbody2D.AddForce(Vector2.down * DownSpeed);

            yield return new WaitForSeconds(0.2f);

            IsAttack = true;

            yield return new WaitForSeconds(1);

            IsAttack = false;
        }
    }
}