using System;
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

        public int GetInventoryCapacityCount()
        {
            if (_inventory == null)
                throw new NullReferenceException(nameof(_inventory));

            return _inventory.CountItems;
        }
        
        public Item[] GetItems(int count)
        {
            if (_inventory == null)
                throw new NullReferenceException(nameof(_inventory));
            
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count) + " must be greater than or equal to zero");
            
            if (_inventory.CountItems >= count)
            {
                Item[] items = new Item[count];
                
                for (int i = 0; i < count; i++)
                {
                    items[i] = _inventory.GetItem();
                }
                
                return items;
            }
            
            throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}