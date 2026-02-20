using System;
using DG.Tweening;
using UnityEngine;

namespace ItemSystem
{
    public class ItemCollectionAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.3f;
        
        private const float ScaleOnCollect = 2;
        
        private Transform _transform;

        public void SetTransform(Transform victimTransform)
        {
            if (victimTransform == null)
                return;
            
            _transform = victimTransform;
        }
        
        public void PlayCollectionAnimation(Vector3[] path, Vector3 peakLocalPos, Action onComplete = null)
        {
            if (_transform == null)
                return;
            
            _transform.localRotation = Quaternion.identity;
            _transform.DOScale(Vector3.one * ScaleOnCollect, _duration).SetEase(Ease.OutSine);
            _transform.DOLocalMove(peakLocalPos, _duration);
            _transform.DOLocalPath(path, _duration, PathType.CatmullRom).SetEase(Ease.OutQuad).OnComplete(() => onComplete?.Invoke());
        }
    }
}