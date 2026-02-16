using System;
using System.Collections.Generic;
using Blocks;
using UnityEngine;
using Upgrades;

namespace InventorySystem
{
    public class Inventory : LevelableEntity
    {
        [SerializeField] private int _maxBlocksCount;
        
        private readonly Stack<Item> _items = new Stack<Item>();

        public int CountItems => _items.Count;
        public bool CanAddItem => _items.Count < _maxBlocksCount;

        private void Awake()
        {
            StartValue = _maxBlocksCount;
        }

        public void AddItem(Item item)
        {
            if (CanAddItem)
            {
                _items.Push(item);
            }
        }

        public Item GetItem()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException(nameof(_items) + " is empty");
            
            Item item = _items.Pop();
            return item;
        }

        public override void Upgrade(float capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, $"{nameof(capacity)} cannot be negative");
            
            _maxBlocksCount = Convert.ToInt32(capacity);
            base.Upgrade(capacity);
        }
    }
}