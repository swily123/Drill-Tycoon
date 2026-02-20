using UnityEngine;

namespace Player
{
    public class PlayerPhysics : MonoBehaviour
    {
        [SerializeField] private float _gravityScaler = 100f;
        
        private Rigidbody _rigidbody;

        public void Initialize(Rigidbody parentRigidbody)
        {
            _rigidbody = parentRigidbody;
        }
        
        private void FixedUpdate()
        {
            _rigidbody?.AddForce(Vector3.down * _gravityScaler, ForceMode.Acceleration);
        }
    }
}