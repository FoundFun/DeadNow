using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroIdle : MonoBehaviour
    {
        private IInputService _inputService;
        private HeroAnimator _heroAnimator;
        private float _direction;

        private void Awake()
        {
            _heroAnimator = GetComponent<HeroAnimator>();
            
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            _direction = _inputService.Axis.x;

            if (_direction == 0)
                _heroAnimator.Idle();
        }
    }
}