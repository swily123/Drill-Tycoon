using System.Collections;
using UnityEngine;

namespace Blocks
{
    public class Item : MonoBehaviour
    {
        public bool IsCollected { get; private set; }
        
        public void Collect(Transform parent, Vector3 localPosition)
        {
            if (IsCollected) return;
            IsCollected = true;
    
            if (TryGetComponent(out Collider col))
                col.enabled = false;
    
            transform.SetParent(parent);
            transform.localPosition = localPosition;
        }
    }
}