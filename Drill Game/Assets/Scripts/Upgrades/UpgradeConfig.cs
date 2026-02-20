using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "UpgradesConfig", menuName = "Configs/Config Upgrades")]
    public class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private LevelData[] _levels;
        
        [Serializable]
        public class LevelData
        {
            public int Level;
            public int Cost;
            public float Value;
        }
        
        public int GetCost(int level)
        {
            foreach (LevelData data in _levels)
            {
                if (data.Level == level)
                    return data.Cost;
            }
        
            throw new ArgumentOutOfRangeException($"Level {level} not configured!");
        }
        
        public float GetValue(int level)
        {
            foreach (LevelData data in _levels)
            {
                if (data.Level == level)
                    return data.Value;
            }
        
            throw new Exception($"Level {level} not configured!");
        }
        
        public bool HasLevel(int level)
        {
            foreach (LevelData data in _levels)
            {
                if (data.Level == level)
                    return true;
            }
            return false;
        }
    }
}