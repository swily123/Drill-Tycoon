using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private float _rotationMinSpeed = 10f;
        [SerializeField] private float _rotationMaxSpeed = 20f;
        [SerializeField] private float _rotationRatio = 1f;
        [SerializeField] private float _inputSmoothing = 5f;
        
        private const float MaxAngle = 150;
        private Transform _transform;
        private Vector3 _smoothedLookRotation;

        private void Awake()
        {
            _transform = transform;
        }

        public void Rotate(Vector3 lookRotation)
        {
            lookRotation.y = 0;
            lookRotation *= -1;
            
            _smoothedLookRotation = Vector3.Lerp(_smoothedLookRotation, lookRotation, Time.deltaTime * _inputSmoothing);
            Quaternion targetRotation = Quaternion.LookRotation(_smoothedLookRotation);
            float angle = Quaternion.Angle(_transform.rotation, targetRotation);
            
            if (angle > MaxAngle)
            {
                _transform.rotation = targetRotation;
            }
            else
            {
                float rotationSpeed = Unity.Mathematics.math.remap(0f, MaxAngle, _rotationMinSpeed, _rotationMaxSpeed, angle);
                _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * rotationSpeed * _rotationRatio);
            }
        }
    }
}