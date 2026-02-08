using System;
using Blocks;
using InventorySystem;
using UnityEngine;

namespace Player
{
    public class ButtonPresser : MonoBehaviour
    {
        private Inventory _inventory;

        public void SetInventory(Inventory inventory)
        {
            _inventory = inventory;
        }

        public Item GetNextItem()
        {
            if (_inventory != null)
            {
                return _inventory.GetItem();
            }
            else
            {
                throw new NullReferenceException(nameof(_inventory));
            }
        }

        public bool IsInventoryNotEmpty()
        {
            if (_inventory == null)
                throw new NullReferenceException(nameof(_inventory));

            return _inventory.CountItems > 0;
        }
    }
}