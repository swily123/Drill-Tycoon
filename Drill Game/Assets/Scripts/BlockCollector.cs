using UnityEngine;

public class BlockCollector : MonoBehaviour
{
    [SerializeField] private int _maxBlocksCount;
    
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory(_maxBlocksCount);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_inventory.IsFree == false)
            return;
        
        if (other.transform.TryGetComponent(out Item item))
        {
            _inventory.AddBlock();
            item.Collect();
        }
    }
}