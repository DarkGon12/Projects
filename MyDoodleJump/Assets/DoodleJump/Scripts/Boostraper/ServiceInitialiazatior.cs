using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Boostraper
{
    public class ServiceInitialiazatior : MonoBehaviour
    {
        public static IInputService InputService;

        public ServiceInitialiazatior()
        {
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            if (Application.isMobilePlatform)
                InputService = new AcceleratioInputService();
            else if (!Application.isMobilePlatform)
                InputService = new StandaloneInputService();
        }
    }
}