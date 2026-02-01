using UnityEngine;

namespace Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private Item _item;
    
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
            Destroy(gameObject);
            Instantiate(_item, transform.position, Quaternion.identity);
        }
    }
}