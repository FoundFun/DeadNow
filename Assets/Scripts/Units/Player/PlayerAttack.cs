using System.Collections;
using UnityEngine;

namespace CodeBase.Hero
{
    public class PlayerAttack : MonoBehaviour
    {   
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private AudioSource AttackSound;

        private const float _downSpeed = 0.1f;

        private bool _delay;
    
        public bool IsAttack { get; private set; }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) && !_delay)
            {
                _delay = true;
                
                AttackSound.Play();

                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            _animator.SetAnimation(PlayerAnimator.AttackHash);
        
            _rigidbody2D.AddForce(Vector2.down * _downSpeed);
        
            yield return new WaitForSeconds(0.2f);
        
            IsAttack = true;

            yield return new WaitForSeconds(1);

            _delay = false;
            IsAttack = false;
        }
    }
}
