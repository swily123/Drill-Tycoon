using DrillSystem;
using UnityEngine;

namespace Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private float _health;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out Drill drill))
            {
                drill.OnContact(this);
            }
        }

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

        public bool IsDieOnDamage(float damage)
        {
            return damage >= _health;
        }
        
        private void Die()
        {
            ItemPool.Instance.GetObject();
            Destroy(gameObject);
        }
    }
}