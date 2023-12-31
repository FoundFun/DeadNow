﻿using CodeBase.Environment;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HeroAnimator))]
    [RequireComponent(typeof(AudioSource))]
    public class HeroJump : MonoBehaviour
    {
        [SerializeField] private AudioClip _jump;
        [SerializeField] private float _jumpForce;

        private HeroInput _input;
        private Rigidbody2D _rigidbody2D;
        private HeroAnimator _animator;
        private AudioSource _audioSource;
        private bool _isGround;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<HeroAnimator>();
            _audioSource = GetComponent<AudioSource>();
            
            _input = new HeroInput();
            
            _input.Hero.Jump.performed += _ => OnJump();
        }

        private void OnEnable()
        {
            _input.Enable();
            EventBus.Instance.HeroJump += OnJump;
        }

        private void OnDisable()
        {
            _input.Disable();
            EventBus.Instance.HeroJump -= OnJump;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ground>()) 
                _isGround = true;
        }

        private void OnJump()
        {
            if (!_isGround)
                return;

            _isGround = false;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(_jump);
            _animator.Jump();
        }
    }
}