using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Inventory/Config")]
    public class InventoryViewConfig : ScriptableObject
    {
        [SerializeField] private int _maxBlocks;
        public int MaxBlocks => _maxBlocks;
    }
}