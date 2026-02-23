using System;
using UnityEngine;

namespace CameraSystem
{
    public class Zone : MonoBehaviour
    {
        public event Action<bool> ZoneEntered;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ZoneTarget>(out _))
            {
                ZoneEntered?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<ZoneTarget>(out _))
            {
                ZoneEntered?.Invoke(false);
            }
        }
    }
}