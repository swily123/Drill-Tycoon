using System;
using UnityEngine;

namespace Upgrades
{
    public class EntityUpgrader : MonoBehaviour
    {
        [SerializeField] private LevelableEntity _entity;
        [SerializeField] private UpgradeConfig _config;

        public int NextLevel => _entity.Level + 1;
        
        public event Action MaxLevelReached;
        
        public int GetUpgradeCost()
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

        public float GetUpgradeValue(int level)
        {
            if (level == 1)
            {
                return _entity.StartValue;
            }
            else
            {
                try
                {
                    return _config.GetValue(level);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                    throw;
                }
            }
        }

        public int GetLevel()
        {
            return _entity.Level;
        }
        
        public void ApplyUpgrade()
        {
            try
            {
                float value = _config.GetValue(NextLevel);
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