using Player;
using UnityEngine;
using UnityEngine.Pool;

namespace ItemSystem
{
    public class ItemPool : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Item _itemPrefab;
        [SerializeField] private int _defaultCapacity = 20;
        [SerializeField] private int _poolMaxSize = 5000;
        
        public static ItemPool Instance { get; private set; }
        
        private ObjectPool<Item> _pool;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _pool = new ObjectPool<Item>(
                createFunc: Spawn,
                actionOnGet: ActionOnGet,
                actionOnRelease: ActionOnRelease,
                actionOnDestroy: (obj) => Destroy(obj.gameObject),
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _poolMaxSize);
        }

        public void ReleaseObject(Item item)
        {
            _pool.Release(item);
        }

        public Item GetObject()
        {
            return _pool.Get();
        }
        
        private Item Spawn()
        {
            if (_pool.CountAll >= _poolMaxSize)
            {
                Debug.LogWarning("Pool Full");
                return null;
            }
            
            Item item = Instantiate(_itemPrefab);
            return item;
        }
        
        private void ActionOnGet(Item item)
        {
            item.gameObject.SetActive(true);
            item.Configure(_spawner.GetSpawnPoint());
        }

        private void ActionOnRelease(Item item)
        {
            @item.gameObject.SetActive(false);
        }
    }
}