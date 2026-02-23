using System;
using UnityEngine;

namespace CameraSystem
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/Camera Config")]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private LevelData[] _levels;
        
        [Serializable]
        private class LevelData
        {
            public int BlocksCount;
            public Vector3 Offset;
        }

        public Vector3 GetOffset(int blocksCount)
        {
            foreach (LevelData data in _levels)
            {
                if (data.BlocksCount == blocksCount)
                {
                    return data.Offset;
                }
            }
            
            throw new ArgumentOutOfRangeException($"BlocksCount {blocksCount} not configured!");
        }
    }
}