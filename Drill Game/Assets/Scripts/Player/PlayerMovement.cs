using System;
using UnityEngine;
using Upgrades;

namespace Player
{
    public class PlayerMovement : LevelableEntity
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _speedMultiplierFactor = 10f;
        [SerializeField] private float _acceleration = 5f;
        [SerializeField] private float _deceleration = 8f;

        public event Action Moving;
        public float CurrentSpeed => _speed;
        public bool IsSlowDownModeActive;

        private const float DecelerationDegree = 2;
        private const float SpeedDivider = 0.1f;
        
        private Vector3 _velocitySmoothing;
        private Rigidbody _rigidbody;
        private float _originalSpeed;

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
            
            Vector3 targetVelocity = direction * (_speed * _speedMultiplierFactor);
            Vector3 currentVelocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
    
            float currentSpeed = currentVelocity.magnitude;
            float lerpSpeed;
    
            if (direction == Vector3.zero)
            {
                lerpSpeed = _deceleration + Mathf.Pow(currentSpeed * SpeedDivider, DecelerationDegree);
            }
            else
            {
                Moving?.Invoke();
                lerpSpeed = _acceleration / (1f + currentSpeed * SpeedDivider);
            }
    
            Vector3 newVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * lerpSpeed);
            _rigidbody.velocity = new Vector3(newVelocity.x, _rigidbody.velocity.y, newVelocity.z);
        }

        public override void Upgrade(float speed)
        {
            if (speed <= 0)
                throw new ArgumentException("Speed cannot be less or equal to zero.");

            if (IsSlowDownModeActive)
                _originalSpeed = speed;
            else
                _speed = speed;
            
            base.Upgrade(speed);
        }

        public void SlowDown(float speedDeceleration)
        {
            if (speedDeceleration <= 0)
                throw new ArgumentException("Speed Deceleration cannot be less or equal to zero.");
            
            IsSlowDownModeActive = true;
            _originalSpeed = _speed;
            _speed /= speedDeceleration;
        }
        
        public void RestoreSpeed()
        {
            IsSlowDownModeActive = false;
            _speed = _originalSpeed;
        }
    }
}