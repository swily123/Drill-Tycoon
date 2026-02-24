using System;
using UnityEngine;

namespace Player
{
    public class PlayerEconomic : MonoBehaviour
    {
        public static PlayerEconomic Instance { get; private set; }
        
        public event Action OnMoneyChanged;
        public event Action<float> OnMoneyChangedValue;
        public float Money => _money;
        
        [SerializeField] private Shop _shop;
        
        private float _money;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            _shop.ItemPurchased += IncreaseMoney;
        }

        private void OnDisable()
        {
            _shop.ItemPurchased -= IncreaseMoney;
        }

        public bool IsEnoughMoney(float cost)
        {
            if (cost < 0)
                throw new ArgumentException(nameof(cost) + " cannot be negative");
            
            return _money >= cost;
        }

        public void SpendMoney(float cost)
        {
            if (IsEnoughMoney(cost) == false)
            {
                Debug.LogWarning($"[Economy] Not enough money! Have {_money}, need {cost}");
                return;
            }
            
            float newMoney = _money - cost;
            OnMoneyChangedValue?.Invoke(newMoney);
            _money = newMoney;
            OnMoneyChanged?.Invoke();
        }
        
        private void IncreaseMoney(float itemCost)
        {
            if (itemCost <= 0)
            {
                return;
            }
            
            float newMoney = _money + itemCost;
            OnMoneyChangedValue?.Invoke(newMoney);
            _money = newMoney;
            OnMoneyChanged?.Invoke();
        }

        [ContextMenu("Billionaire")]
        private void BecomeBillionaire()
        {
            IncreaseMoney(9999999);
        }
        
        [ContextMenu("Bankrupt")]
        private void BecomeBankrupt()
        {
            SpendMoney(_money);
        }
    }
}