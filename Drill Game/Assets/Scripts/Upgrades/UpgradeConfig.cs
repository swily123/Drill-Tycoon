using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "MovementUpgradeConfig", menuName = "Configs/Movement Upgrade")]
    public class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private LevelData[] Levels;
        
        [System.Serializable]
        public class LevelData
        {
            public int Level;
            public int Cost;
            public int Value;
        }
        
        public int GetCost(int level)
        {
            foreach (LevelData data in Levels)
            {
                if (data.Level == level)
                    return data.Cost;
            }
        
            throw new System.ArgumentOutOfRangeException($"Level {level} not configured!");
        }
        
        public int GetValue(int level)
        {
            foreach (LevelData data in Levels)
            {
                if (data.Level == level)
                    return data.Value;
            }
        
            throw new System.Exception($"Level {level} not configured!");
        }
        
        public bool HasLevel(int level)
        {
            foreach (LevelData data in Levels)
            {
                if (data.Level == level)
                    return true;
            }
            return false;
        }
    }
}