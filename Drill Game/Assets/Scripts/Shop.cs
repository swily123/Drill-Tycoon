using System;
using Blocks;
using Planes;
using Player;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlaneButton _button;
    [SerializeField] private Transform _itemSellPoint;
    [SerializeField] private float _cooldownMax = 0.2f;
    [SerializeField] private float _cooldownMin = 0.01f;
    [SerializeField] private float _cooldownStep = 0.0001f;
    
    public event Action<float> ItemPurchased;
    
    private float _cooldownTimer;
    private float _cooldownNextValue;
    
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
        
        if (buttonPresser.IsInventoryNotEmpty())
        {
            Item item = buttonPresser.GetNextItem();
            item.Collect(_itemSellPoint, Vector3.zero, onComplete: () => ItemPool.Instance.ReleaseObject(item));
            ItemPurchased?.Invoke(item.Cost);
            _cooldownNextValue = Mathf.MoveTowards(_cooldownNextValue, _cooldownMin, _cooldownStep);
            _cooldownTimer = _cooldownNextValue;
        }
    }

    private void OnReleaseButton()
    {
        _cooldownTimer = _cooldownMax;
        _cooldownNextValue = _cooldownMax;
    }
}