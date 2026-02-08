using DG.Tweening;
using UnityEngine;

namespace Blocks
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int _cost = 1;
        private const float PeakAmplitude = 5;

        public bool IsCollected { get; private set; }
        public int Cost => _cost;
        
        public void Collect(Transform parent, Vector3 localTargetPosition, float duration = 0.3f)
        {
            IsCollected = true;
            Vector3 startWorldPos = transform.position;
            transform.SetParent(parent);
            Vector3 startLocalPos = parent.InverseTransformPoint(startWorldPos);
            Vector3 peakLocalPos = (startLocalPos + localTargetPosition) / 2 + Vector3.up * PeakAmplitude; //TODO 2 вынести в константу

            Vector3[] path = new Vector3[] 
            { 
                startLocalPos,
                peakLocalPos,
                localTargetPosition
            };
        
            transform.localRotation = Quaternion.identity;
            transform.DOLocalPath(path, duration, PathType.CatmullRom).SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    //TODO звук/эффекты
                });
        }
    }
}