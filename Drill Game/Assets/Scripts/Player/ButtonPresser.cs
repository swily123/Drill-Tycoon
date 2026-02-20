using System;
using Blocks;
using InventorySystem;
using ItemSystem;
using UnityEngine;

namespace Player
{
    public class ButtonPresser : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

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