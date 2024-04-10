using UnityEngine;

namespace Scripts.Services.Input
{
    public class AcceleratioInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(UnityEngine.Input.acceleration.x, UnityEngine.Input.acceleration.y);
                return axis;
            }
        }
    }
}