using DG.Tweening;
using UnityEngine;

namespace Blocks
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _cost = 1;
        
        private const float PeakAmplitude = 5;
        private const float ScaleOnCollect = 2;
        private const float Half = 2;

        public bool IsCollected { get; private set; }
        public float Cost => _cost;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Collect(Transform parent, Vector3 localTargetPosition, float duration = 0.3f)
        {
            if (_transform == null)
                return;
            
            IsCollected = true;
            Vector3 startWorldPos = _transform.position;
            _transform.SetParent(parent);
            Vector3 startLocalPos = parent.InverseTransformPoint(startWorldPos);
            Vector3 peakLocalPos = (startLocalPos + localTargetPosition) / Half + Vector3.up * PeakAmplitude;

            Vector3[] path = new Vector3[] 
            { 
                startLocalPos,
                peakLocalPos,
                localTargetPosition
            };
        
            _transform.localRotation = Quaternion.identity;
            _transform.DOScale(Vector3.one * ScaleOnCollect, duration).SetEase(Ease.OutSine);
            _transform.DOLocalMove(peakLocalPos, duration);
            _transform.DOLocalPath(path, duration, PathType.CatmullRom).SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    //TODO звук/эффекты
                });
        }

        public void Configure(Transform parent)
        {
            if (_transform == null)
                return;
            
            _transform.position = parent.transform.position;
            _transform.rotation = Quaternion.identity;
        }
    }
}