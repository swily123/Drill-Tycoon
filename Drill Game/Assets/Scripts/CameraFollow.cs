using InventorySystem;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private InventoryViewConfig _inventoryViewConfig;
    [SerializeField] private CinemachineFollow _cinemachineFollow;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Vector3 _minOffset;
    [SerializeField] private Vector3 _maxOffset;

    private void OnEnable()
    {
        _inventory.OnCountChanged += ChangeOffset;
    }

    private void OnDisable()
    {
        _inventory.OnCountChanged -= ChangeOffset;
    }

    private void ChangeOffset(int count)
    {
        float y = math.remap(0, _inventoryViewConfig.MaxBlocks, _minOffset.y, _maxOffset.y, count);
        float z = math.remap(0, _inventoryViewConfig.MaxBlocks, _minOffset.z, _maxOffset.z, count);

        if (y > _maxOffset.y)
            y = _maxOffset.y;
        
        if (z > _maxOffset.z)
            z = _maxOffset.z;
        
        _cinemachineFollow.FollowOffset = new Vector3(_minOffset.x, y, z);
    }
}