using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Configs/Item Data")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private Material _material;
        [SerializeField, Min(0)] private float _cost;
        
        public Material Material => _material;
        public float Cost => _cost;
    }
}