using System.Collections;
using UnityEngine;

namespace SpecialOffers
{
    public abstract class SpecialOffer : MonoBehaviour
    {
        [SerializeField] private float _duration;
        
        private Coroutine _coroutine;
        
        public void Activate()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(RoutineSpecialOffer());
            OnActivated();
        }

        protected abstract void OnActivated();
        
        protected abstract void Deactivate();
        
        private IEnumerator RoutineSpecialOffer()
        {
            yield return new WaitForSeconds(_duration);
            Deactivate();
        }
    }
}