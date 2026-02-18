using UnityEngine;

namespace InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryViewConfig _config;
        [SerializeField] private Transform _firstSlot;
        [SerializeField] private float _xOffset;
        [SerializeField] private float _zOffset;
        [SerializeField] private float _yOffset;

        private const int RowCount = 4;
        private const int FloorCount = 16;
        private Vector3 _maxBlocksViewPosition;
        
        public Vector3 GetNextLocalPosition(int index)
        {
            if (index > _config.MaxBlocks)
            {
                return _maxBlocksViewPosition;
            }
            
            int floor = index / FloorCount;
            int indexOnFloor = index % FloorCount;
            int row = indexOnFloor / RowCount;
            int col = indexOnFloor % RowCount;
    
            Vector3 localOffset = new Vector3(col * _xOffset, floor * _yOffset, row * _zOffset);

            if (index == _config.MaxBlocks)
            {
                _maxBlocksViewPosition = localOffset;
            }
            
            return localOffset;
        }
    }
}