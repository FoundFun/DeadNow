using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Button = "Attack";
        private const  string Squat = "Squat";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(Button);
        }

        public bool IsSquatButtonUp()
        {
            return SimpleInput.GetButtonUp(Squat);
        }

        protected static Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
    }
}