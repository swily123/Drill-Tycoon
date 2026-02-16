using System;
using UnityEngine;
using Upgrades;

namespace Player
{
    public class PlayerMovement : LevelableEntity
    {
        [SerializeField] private float _speed;
        
        public event Action<float> Upgraded;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            StartValue = _speed;
        }

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

        public override void Upgrade(float speed)
        {
            if (speed <= 0)
                throw new ArgumentException("Speed cannot be less or equal to zero.");
            
            _speed = speed;
            base.Upgrade(speed);
            Upgraded?.Invoke(speed);
        }
    }
}