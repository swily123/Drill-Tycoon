using System;
using UnityEngine;

namespace ItemSystem
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Item : MonoBehaviour
    {
        [Header("Responsibilities")]
        [SerializeField] private ItemCollectionState _itemState;
        [SerializeField] private ItemCollectionAnimation _itemAnimation;
        [SerializeField] private ItemPhysics _itemPhysics;
        
        private const float PeakAmplitude = 5;
        private const float Half = 2;
        
        private Vector3 _normalScale;
        private float _cost = 1;

        public float Cost => _cost;
        public ItemCollectionState CollectionState => _itemState;
        
        private Transform _transform;
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        private ItemVisuals _itemVisuals;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            
            _itemVisuals = new ItemVisuals();
            _itemState.SetGameObject(gameObject);
            _itemAnimation.SetTransform(_transform);
            _itemPhysics.SetRigidbody(_rigidbody);
            _itemVisuals.SetRenderer(_renderer);
            
            _normalScale = _transform.localScale;
        }

        public void Collect(Transform parent, Vector3 localTargetPosition, Action onComplete = null)
        {
            if (_transform == null)
                return;
            
            _itemPhysics.Freeze();
            _itemPhysics.SetMass(true);
            _itemState.SetImmune(false);
            
            Vector3 startWorldPos = _transform.position;
            _transform.SetParent(parent);
            Vector3 startLocalPos = parent.InverseTransformPoint(startWorldPos);
            Vector3 peakLocalPos = (startLocalPos + localTargetPosition) / Half + Vector3.up * PeakAmplitude;
            Vector3[] path = { startLocalPos, peakLocalPos, localTargetPosition };

            if (onComplete != null)
            {
                _itemAnimation.PlayCollectionAnimation(path, peakLocalPos, onComplete);
            }
            else
            {
                _itemAnimation.PlayCollectionAnimation(path, peakLocalPos);
            }
            
            _itemState.OnCollect();
        }

        public void Configure(Transform parent)
        {
            if (_transform == null)
                return;
            
            SetNonCollectible();
            _itemPhysics.Freeze(false);
            _itemPhysics.ApplySpawnForce(parent.forward);
            _transform.localScale = _normalScale;
            _transform.position = parent.transform.position;
            _transform.rotation = parent.transform.rotation;
        }

        public void SetData(ItemData data)
        {
            if (data == null)
                return;
            
            _cost = data.Cost;
            _itemVisuals.SetMaterial(data.Material);
        }
        
        private void SetNonCollectible()
        {
            _itemPhysics.SetMass(false);
            _itemState.SetImmune();
        }
    }
}