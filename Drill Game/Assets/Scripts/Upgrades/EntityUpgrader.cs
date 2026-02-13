using System;
using UnityEngine;

namespace Upgrades
{
    public class EntityUpgrader : MonoBehaviour
    {
        [SerializeField] private LevelableEntity _entity;
        [SerializeField] private UpgradeConfig _config;

        private int NextLevel => _entity.Level + 1;
        
        public event Action MaxLevelReached;
        
        public float GetUpgradeCost()
        {
            try
            {
                return _config.GetCost(NextLevel);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
        }

        public void ApplyUpgrade()
        {
            try
            {
                var value = _config.GetValue(NextLevel);
                _entity.Upgrade(value);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            CheckMaxLevelReached();
        }

        private void CheckMaxLevelReached()
        {
            if (_config.HasLevel(NextLevel) == false)
                MaxLevelReached?.Invoke();
        }
    }
}