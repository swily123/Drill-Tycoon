using DrillSystem;
using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(BoxCollider))]
    public class Block : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private Material _itemDropMaterial;
        
        private const float CooldownDelay = 0.1f;
        private float _hitCooldown;
        private float _hitTimer;
        private BoxCollider _collider;

        private void Awake()
        {
            _hitCooldown = CooldownDelay * _health;
            _collider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CollisionHandler(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            CollisionHandler(other.collider);
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.collider.TryGetComponent(out Drill drill))
            {
                if (_hitTimer >= 0)
                {
                    _hitTimer -= Time.deltaTime;
                }
                else
                {
                    drill.OnContact(this);
                    _hitTimer = _hitCooldown;
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            _hitTimer = _hitCooldown;
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

        public void MakeSolid(bool isTrigger)
        {
            _collider.isTrigger = isTrigger;
        }
        
        private void Die()
        {
            Item item = ItemPool.Instance.GetObject();
            item.SetMaterial(_itemDropMaterial);
            BlocksCounter.Instance.OnBlockDie();
            Destroy(gameObject);
        }

        private void CollisionHandler(Collider other)
        {
            if (other.TryGetComponent(out Drill drill))
            {
                drill.OnContact(this);
            }
        }
    }
}