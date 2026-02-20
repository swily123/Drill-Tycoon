using InventorySystem;
using UnityEngine;
using ItemSystem;

namespace Player
{
    public class BlockCollector : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Transform _slot;
        [SerializeField] private ButtonPresser _buttonPresser;
        [SerializeField] private Inventory _inventory;

        private void OnCollisionEnter(Collision other)
        {
            if (_inventory.CanAddItem == false)
            {
                return;
            }

            if (other.transform.TryGetComponent(out Item item))
            {
                if (_inventory.CanAddItem == false || item.CollectionState.CanBeCollected == false)
                {
                    return;
                }
                
                item.Collect(_slot, _inventoryView.GetNextLocalPosition(_inventory.CountItems));
                _inventory.AddItem(item);
            }
        }
    }
}