using System.Collections;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroTransfer : MonoBehaviour
    {
        public HeroAnimator Animator;
        public Rigidbody2D Rigidbody2D;

        private const float _downSpeed = 0.1f;
    
        public bool IsTransfer { get; private set; }

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
            Animator.Transfer();
            
            Rigidbody2D.AddForce(Vector2.down * _downSpeed);

            yield return new WaitForSeconds(2);

            IsTransfer = false;
        }
    }
}
