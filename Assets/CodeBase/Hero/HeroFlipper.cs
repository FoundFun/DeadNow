using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeroFlipper : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private IInputService _inputService;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            if (_inputService.Axis.x < 0)
                _spriteRenderer.flipX = true;
            else if (_inputService.Axis.x > 0)
                _spriteRenderer.flipX = false;
        }
    }
}