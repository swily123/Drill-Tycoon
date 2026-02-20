using UnityEngine;

namespace ItemSystem
{
    public class ItemPhysics : MonoBehaviour
    {
        [SerializeField] private float _forceFactor = 10f;
        [SerializeField] private float _collectibleMass;
        [SerializeField] private float _nonCollectibleMass;
        
        private Rigidbody _rigidbody;

        public void SetRigidbody(Rigidbody victimRigidbody)
        {
            if (victimRigidbody == null)
                return;
            
            _rigidbody = victimRigidbody;
        }
        
        public void Freeze(bool isCollected = true)
        {
            if (_rigidbody == null)
                return;
            
            if (isCollected)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                _rigidbody.useGravity = false;
            }
            else
            {
                _rigidbody.constraints = RigidbodyConstraints.None;
                _rigidbody.useGravity = true;
            }
        }

        public void ApplySpawnForce(Vector3 direction)
        {
            if (_rigidbody == null)
                return;
            
            _rigidbody.AddForce(direction * _forceFactor, ForceMode.Impulse);
        }

        public void SetMass(bool isCollected)
        {
            if (_rigidbody == null)
                return;
            
            _rigidbody.mass = isCollected ? _collectibleMass : _nonCollectibleMass;
        }
    }
}