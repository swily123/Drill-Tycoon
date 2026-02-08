using System;
using Player;
using UnityEngine;

namespace Planes
{
    public class PlaneButton : MonoBehaviour
    {
        public event Action<ButtonPresser> Activating;
        public event Action Clicked;
        public event Action Released;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<ButtonPresser>(out _))
            {
                Clicked?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.TryGetComponent(out ButtonPresser buttonPresser))
            {
                Activating?.Invoke(buttonPresser);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.TryGetComponent<ButtonPresser>(out _))
            {
                Released?.Invoke();
            }
        }
    }
}