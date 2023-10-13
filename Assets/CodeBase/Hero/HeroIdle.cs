using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroIdle : MonoBehaviour
    {
        public HeroJump HeroJump;

        private HeroAnimator _heroAnimator;
        private float _horizontal;

        private void Awake()
        {
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");

            if (_horizontal == 0 && !HeroJump.IsJump)
                _heroAnimator.Idle();
        }
    }
}