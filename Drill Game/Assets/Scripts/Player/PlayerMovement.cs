using UnityEngine;
using Upgrades;

namespace Player
{
    public class PlayerMovement : LevelableEntity
    {
        [SerializeField] private int _speed;

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

        public override void Upgrade(int speed)
        {
            if (speed <= 0)
                throw new System.ArgumentException("Speed cannot be less or equal to zero.");
            
            _speed = speed;
            base.Upgrade(speed);
            
            Debug.Log("Upgraded to " + Level);
            Debug.Log("Speed " + _speed);
        }
    }
}