using System;
using Player;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeEngine : MonoBehaviour
    {
        [SerializeField] private EntityUpgrader _entityUpgrader;

        public bool MaxLevelReached { get; private set; }
        
        public event Action DisablingButton;
        
        private void OnEnable()
        {
            _entityUpgrader.MaxLevelReached += DisableBuyUpgrade;
        }

        private void OnDisable()
        {
            _entityUpgrader.MaxLevelReached -= DisableBuyUpgrade;
        }

        public bool CanBuyUpgrade()
        {
            return PlayerEconomic.Instance.IsEnoughMoney(_entityUpgrader.GetUpgradeCost());
        }

        public bool TryBuyUpgrade()
        {
            bool canBuy = CanBuyUpgrade();
            
            if (canBuy)
            {
                PlayerEconomic.Instance.SpendMoney(_entityUpgrader.GetUpgradeCost());
                _entityUpgrader.ApplyUpgrade();
            }

            return canBuy;
        }

        public int GetCostUpgrade()
        {
            return _entityUpgrader.GetUpgradeCost();
        }
        
        public int GetEntityLevel()
        {
            return _entityUpgrader.GetLevel();
        }

        public void GetUpgradeValues(int level, out int firstValue, out int secondValue)
        {
            firstValue = _entityUpgrader.GetUpgradeValue(level);
            secondValue = _entityUpgrader.GetUpgradeValue(_entityUpgrader.NextLevel);
        }

        public int GetUpgradeValue(int level)
        {
            return _entityUpgrader.GetUpgradeValue(level);
        }
        
        private void DisableBuyUpgrade()
        {
            DisablingButton?.Invoke();
            MaxLevelReached = true;
        }
    }
}