using System.Collections;
using Blocks;
using UnityEngine;

namespace Player
{
    public class MovementDecelerator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private float _slowdownDuration = 0.2f;
        [SerializeField] private float _slowdownFactor = 2f;
        
        private Coroutine _coroutine;
        private int _blockInTriggerCount;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<Block>(out _))
            {
                _blockInTriggerCount++;
                SlowDown();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.TryGetComponent<Block>(out _))
            {
                if(_blockInTriggerCount > 0)
                    _blockInTriggerCount--;

                SlowDown();
            }
        }

        private void SlowDown()
        {
            if (_blockInTriggerCount > 0)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);
                
                _coroutine = StartCoroutine(Slowing());
            }
        }

        private IEnumerator Slowing()
        {
            if (_playerMovement.IsSlowDownModeActive == false)
            {
                _playerMovement.SlowDown(_slowdownFactor);
            }
            
            yield return new WaitForSeconds(_slowdownDuration);
            _playerMovement.RestoreSpeed();
        }
    }
}