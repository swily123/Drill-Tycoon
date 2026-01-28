using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Rigidbody _rigidbody;

        public void Initialize(Rigidbody parentRigidbody)
        {
            _rigidbody = parentRigidbody;
        }
        
        public void Move(Vector3 direction)
        {
            if (_rigidbody is null)
                return;
            
            Vector3 movement = direction * _speed;
            _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
        }
    }
}