using InventorySystem;
using UnityEngine;
using Blocks;

namespace Player
{
    public class BlockCollector : MonoBehaviour
    {
        [SerializeField] private int _maxBlocksCount;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Transform _slot;
        [SerializeField] private ButtonPresser _buttonPresser;
    
        private Inventory _inventory;
        
        private void Awake()
        {
            _inventory = new Inventory(_maxBlocksCount);
            _buttonPresser.SetInventory(_inventory);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_inventory.CanAddItem == false)
            {
                return;
            }

            if (other.transform.TryGetComponent(out Item item))
            {
                if (item.IsCollected)
                {
                    return;
                }
                
                Vector3 itemPosition = _inventoryView.GetNextLocalPosition(_inventory.CountItems);
                item.Collect(_slot, itemPosition);

                _inventory.AddItem(item);
            }
        }
    }
}