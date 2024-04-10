using UnityEngine;

namespace Scripts.Boostraper
{
    public class Boostraper : MonoBehaviour
    {
        private ServiceInitialiazatior _services;

        private void Awake()
        {
            _services = new ServiceInitialiazatior();

            DontDestroyOnLoad(this);
        }
    }
}