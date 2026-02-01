using DG.Tweening;
using UnityEngine;

namespace Blocks
{
    public class Item : MonoBehaviour
    {
        public bool IsCollected { get; private set; }
    
        public void Collect(Transform parent, Vector3 localTargetPosition, float duration = 0.3f)
        {
            if (IsCollected) return;
            IsCollected = true;
        
            Vector3 startWorldPos = transform.position;
        
            transform.SetParent(parent);
        
            Vector3 startLocalPos = parent.InverseTransformPoint(startWorldPos);
        
            Vector3 peakLocalPos = (startLocalPos + localTargetPosition) / 2 + Vector3.up * 5f;

            Vector3[] path = new Vector3[] 
            { 
                startLocalPos,
                peakLocalPos,
                localTargetPosition
            };
        
            transform.localRotation = Quaternion.identity;
            
            transform.DOLocalPath(path, duration, PathType.CatmullRom)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    //TODO звук/эффекты
                });
        }
    }
}