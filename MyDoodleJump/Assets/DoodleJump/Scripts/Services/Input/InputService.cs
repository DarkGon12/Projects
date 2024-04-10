using UnityEngine;

namespace Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";

        public abstract Vector2 Axis { get; }
    }
}