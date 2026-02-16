using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private float _rotationSpeed = 10f;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            _playerMovement.Upgraded += UpgradeRotationSpeed;
        }

        private void OnDisable()
        {
            _playerMovement.Upgraded -= UpgradeRotationSpeed;
        }

        public void Rotate(Vector3 lookRotation)
        {
            lookRotation.y = 0;
            lookRotation *= -1;
            
            if (Vector3.Angle(_transform.forward, lookRotation) > 120)
            {
                _transform.forward = lookRotation;
            }
            else
            {
               _transform.forward = Vector3.MoveTowards(_transform.forward, lookRotation,  Time.deltaTime * _rotationSpeed);
            }
        }

        private void UpgradeRotationSpeed(float speed)
        {
            if (speed <= 0)
                throw new System.ArgumentException("Speed cannot be less or equal to zero.");
            
            _rotationSpeed = speed;
        }
    }
}