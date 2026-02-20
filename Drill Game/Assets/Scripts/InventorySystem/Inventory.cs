using System;
using System.Collections.Generic;
using ItemSystem;
using UnityEngine;
using Upgrades;

namespace InventorySystem
{
    public class Inventory : LevelableEntity
    {
        [SerializeField] private int _maxBlocksCount;
        
        public event Action<int> OnCountChanged;
        public event Action<int> OnMaxCountChanged;
        
        public int CountItems => _items.Count;
        public bool CanAddItem => _items.Count < _maxBlocksCount;

        private readonly Stack<Item> _items = new();

        private void Awake()
        {
            StartValue = _maxBlocksCount;
        }

        private void Start()
        {
            OnMaxCountChanged?.Invoke(_maxBlocksCount);
            OnCountChanged?.Invoke(_items.Count);
        }

        public void AddItem(Item item)
        {
            if (CanAddItem)
            {
                _items.Push(item);
                OnCountChanged?.Invoke(_items.Count);
            }
        }

        public Item GetItem()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException(nameof(_items) + " is empty");
            
            Item item = _items.Pop();
            OnCountChanged?.Invoke(_items.Count);
            return item;
        }

        public override void Upgrade(float capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, $"{nameof(capacity)} cannot be negative");
            
            _maxBlocksCount = Convert.ToInt32(capacity);
            OnMaxCountChanged?.Invoke(_maxBlocksCount);
            OnCountChanged?.Invoke(_items.Count);
            base.Upgrade(capacity);
        }
    }
}