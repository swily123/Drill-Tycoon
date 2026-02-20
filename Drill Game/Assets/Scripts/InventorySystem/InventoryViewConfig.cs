using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Configs/InventoryConfig")]
    public class InventoryViewConfig : ScriptableObject
    {
        [SerializeField] private int _maxBlocks;
        public int MaxBlocks => _maxBlocks;
    }
}