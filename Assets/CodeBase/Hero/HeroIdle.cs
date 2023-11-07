using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroIdle : MonoBehaviour
    {
        private HeroInput _input;
        private HeroAnimator _heroAnimator;
        private float _direction;

        private void Awake()
        {
            _input = new HeroInput();
            _heroAnimator = GetComponent<HeroAnimator>();
        }

        private void Update()
        {
            _direction = _input.Hero.Move.ReadValue<Vector2>().x;

            if (_direction == 0)
                _heroAnimator.Idle();
        }
    }
}