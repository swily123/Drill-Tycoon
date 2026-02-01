using UnityEngine;
using InventorySystem;

namespace Blocks
{
    public class BlockCollector : MonoBehaviour
    {
        [SerializeField] private int _maxBlocksCount;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Transform _slot;
    
        private Inventory _inventory;
        
        private void Awake()
        {
            _inventory = new Inventory(_maxBlocksCount);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_inventory.IsFree == false)
            {
                return;
            }

            if (other.transform.TryGetComponent(out Item item))
            {
                if (item.IsCollected)
                {
                    return;
                }
                
                Vector3 itemPosition = _inventoryView.GetNextLocalPosition(_inventory.CountBlocks);
                item.Collect(_slot, itemPosition);

                _inventory.AddBlock();
            }
        }
    }
}