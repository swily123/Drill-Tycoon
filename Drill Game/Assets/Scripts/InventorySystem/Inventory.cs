using System;
using System.Collections.Generic;
using Blocks;

namespace InventorySystem
{
    public class Inventory
    {
        private readonly int _maxItemsCount;
        private readonly Stack<Item> _items;
    
        public Inventory(int maxItemsCount)
        {
            _maxItemsCount = maxItemsCount;
            _items = new Stack<Item>();
        }

        public int CountItems => _items.Count;
        public bool CanAddItem => _items.Count <= _maxItemsCount;
    
        public void AddItem(Item item)
        {
            if (CountItems <= _maxItemsCount)
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
    }
}