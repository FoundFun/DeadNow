using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroJump : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public HeroAnimator Animator;
        public float Force;
        
        public bool IsGround { get; private set; }
        public bool IsJump { get; private set; }

        private void Update()
        {
            Vector2 rigidbody = Rigidbody2D.velocity;

            if (rigidbody.y > 5)
            {
                rigidbody.y = 5;
                Rigidbody2D.velocity = rigidbody;
            }
            else if (rigidbody.y < -5)
            {
                rigidbody.y = -5;
                Rigidbody2D.velocity = rigidbody;
            }
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space) && IsGround && !IsJump)
            {
                IsJump = true;
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0);

                Rigidbody2D.AddForce(new Vector2(Rigidbody2D.velocity.x, Force), ForceMode2D.Impulse);
                Animator.Jump();
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.GetComponent<Ground>())
            {
                IsJump = false;
                IsGround = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Ground>())
            {
                IsJump = false;
                IsGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Ground>())
                IsGround = false;
        }
    }
}