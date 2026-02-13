using System;
using Blocks;
using Planes;
using Player;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlaneButton _button;
    [SerializeField] private Transform _itemSellPoint;
    [SerializeField] private float _cooldown = 0.1f;
    
    public event Action<float> ItemPurchased;
    
    private float _cooldownTimer;
    
    private void OnEnable()
    {
        _button.Activating += OnActive;
    }

    private void OnDisable()
    {
        _button.Activating -= OnActive;
    }
 
    private void OnActive(ButtonPresser buttonPresser)
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            return;
        }
        
        if (buttonPresser.IsInventoryNotEmpty())
        {
            _cooldownTimer = _cooldown;
            Item item = buttonPresser.GetNextItem();
            item.Collect(_itemSellPoint, Vector3.zero);
            ItemPurchased?.Invoke(item.Cost);
        }
    }
}