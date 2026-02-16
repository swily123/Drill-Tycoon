using UnityEngine;

namespace Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private float _health;
    
        public void TakeDamage(float damage)
        {
            if (damage < 0)
                return;
        
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Item item = ItemPool.Instance.GetObject();
            item.Configure(transform);
            Destroy(gameObject);
        }
    }
}