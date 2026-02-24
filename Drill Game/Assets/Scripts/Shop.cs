using System;
using ItemSystem;
using Planes;
using Player;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlaneButton _button;
    [SerializeField] private Transform _itemSellPoint;
    [SerializeField] private float _cooldown = 0.1f;
    [SerializeField] private int _maxBlocksPerOrder = 10;
    
    public event Action<float> ItemPurchased;
    
    private float _cooldownTimer;
    
    private void OnEnable()
    {
        OnReleaseButton();
        _button.Activating += OnActive;
        _button.Released += OnReleaseButton;
    }

    private void OnDisable()
    {
        _button.Activating -= OnActive;
        _button.Released -= OnReleaseButton;
    }
 
    private void OnActive(ButtonPresser buttonPresser)
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            return;
        }
        
        int inventoryCapacity = buttonPresser.GetInventoryCapacityCount();
        
        if (inventoryCapacity > 0)
        {
            if (inventoryCapacity >= _maxBlocksPerOrder)
            {
                inventoryCapacity = _maxBlocksPerOrder;
            }

            float orderCost = 0;
            
            foreach (Item item in buttonPresser.GetItems(inventoryCapacity))
            {
                item.Collect(_itemSellPoint, Vector3.zero, onComplete: () => ItemPool.Instance.ReleaseObject(item));
                orderCost += item.Cost;
                _cooldownTimer = _cooldown;
            }
            
            ItemPurchased?.Invoke(orderCost);
        }
    }

    private void OnReleaseButton()
    {
        _cooldownTimer = _cooldown;
    }
}