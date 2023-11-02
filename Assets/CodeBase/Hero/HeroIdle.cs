using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroIdle : MonoBehaviour
    {
        private HeroAnimator _heroAnimator;
        private float _horizontal;

        private void Awake()
        {
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");

            if (_horizontal == 0)
                _heroAnimator.Idle();
        }
    }
}