using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1f;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
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
    }
}