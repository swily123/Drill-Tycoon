using UnityEngine;

namespace InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _firstSlot;
        [SerializeField] private float _xOffset;
        [SerializeField] private float _zOffset;
        [SerializeField] private float _yOffset;

        private const int RowCount = 3;
        private const int FloorCount = 9;

        public Vector3 GetNextLocalPosition(int index)
        {
            int floor = index / FloorCount;
            int indexOnFloor = index % FloorCount;
            int row = indexOnFloor / RowCount;
            int col = indexOnFloor % RowCount;
    
            Vector3 localOffset = new Vector3(
                col * _xOffset,
                floor * _yOffset,
                row * _zOffset
            );
    
            return localOffset;
        }
    }
}