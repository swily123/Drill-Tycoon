using System;
using Player;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeEngine : MonoBehaviour
    {
        [SerializeField] private EntityUpgrader _entityUpgrader;
        
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

        public void TryBuyUpgrade()
        {
            if (CanBuyUpgrade())
            {
                PlayerEconomic.Instance.SpendMoney(_entityUpgrader.GetUpgradeCost());
                _entityUpgrader.ApplyUpgrade();
            }
        }

        private void DisableBuyUpgrade()
        {
            DisablingButton?.Invoke();
        }
    }
}