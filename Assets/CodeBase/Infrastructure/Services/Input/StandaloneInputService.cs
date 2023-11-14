using UnityEngine;

namespace CodeBase.Services.Input
{
    public class StandaloneInputService : InputService
    {
        private readonly HeroInput _input;

        public StandaloneInputService(HeroInput heroInput)
        {
            _input = heroInput;
            _input.Enable();
        }

        ~StandaloneInputService() => 
            _input.Disable();

        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                {
                    axis = UnityAxis();
                }

                return axis;
            }
        }

        private Vector2 UnityAxis() => 
            _input.Hero.Move.ReadValue<Vector2>();
    }
}