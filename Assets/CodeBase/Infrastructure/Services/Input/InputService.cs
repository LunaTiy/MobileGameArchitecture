using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string Fire = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(Fire);

        protected static Vector2 GetSimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}