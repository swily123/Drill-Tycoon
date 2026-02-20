using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _cost = 1;
        [SerializeField] private float _immuneDelay = 1f;
        [SerializeField] private float _forceFactor = 10f;
        [SerializeField] private LayerMask _nonCollectibleMask;
        [SerializeField] private LayerMask _collectibleMask;
        [SerializeField] private float _collectibleMass;
        [SerializeField] private float _nonCollectibleMass;
        [SerializeField] private Vector3 _normalScale;
        
        private const float PeakAmplitude = 5;
        private const float ScaleOnCollect = 2;
        private const float Half = 2;

        public bool IsCollected { get; private set; }
        public bool CanBeCollected { get; private set; }
        public float Cost => _cost;
        
        private Transform _transform;
        private Rigidbody _rigidbody;
        private Renderer _renderer;
        private Coroutine _immuneCoroutine;
        
        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _renderer = GetComponent<Renderer>();
            SetNonCollectible();
        }

        public void Collect(Transform parent, Vector3 localTargetPosition, float duration = 0.3f, Action onComplete = null)
        {
            if (_transform == null)
                return;
            
            if (IsCollected == false)
                Freeze();
            
            IsCollected = true;
            Vector3 startWorldPos = _transform.position;
            _transform.SetParent(parent);
            Vector3 startLocalPos = parent.InverseTransformPoint(startWorldPos);
            Vector3 peakLocalPos = (startLocalPos + localTargetPosition) / Half + Vector3.up * PeakAmplitude;

            Vector3[] path = { startLocalPos, peakLocalPos, localTargetPosition };
            
            _rigidbody.mass = _collectibleMass;
            _transform.localRotation = Quaternion.identity;
            _transform.DOScale(Vector3.one * ScaleOnCollect, duration).SetEase(Ease.OutSine);
            _transform.DOLocalMove(peakLocalPos, duration);
            _transform.DOLocalPath(path, duration, PathType.CatmullRom).SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                    //TODO звук/эффекты
                });
        }

        public void Configure(Transform parent)
        {
            if (_transform == null)
                return;

            if (_immuneCoroutine != null)
            {
                StopCoroutine(_immuneCoroutine);
            }

            SetNonCollectible();
            _transform.localScale = _normalScale;
            _rigidbody.AddForce(parent.forward * _forceFactor, ForceMode.Impulse);
            _transform.position = parent.transform.position;
            _transform.rotation = parent.transform.rotation;
        }

        public void SetMaterial(Material material)
        {
            if (material == null)
                return;
            
            _renderer.material = material;
        }
        
        private void SetNonCollectible()
        {
            _rigidbody.mass = _nonCollectibleMass;
            _transform.gameObject.layer = (int)Mathf.Log(_nonCollectibleMask.value, 2);
            Freeze(false);
            StartCoroutine(ImmuneToCollected());
        }
        
        private void Freeze(bool isCollected = true)
        {
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

        private IEnumerator ImmuneToCollected()
        {
            yield return new WaitForSeconds(_immuneDelay);
            _transform.gameObject.layer = (int)Mathf.Log(_collectibleMask.value, 2);
            CanBeCollected = true;
            IsCollected = false;
        }
    }
}