using UnityEngine;

namespace Player
{
    public class DrillCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Collider _drillCollider;
        [SerializeField] private Drill _drill;
    
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.GetContact(0).thisCollider == _drillCollider)
            {
                if (collision.transform.TryGetComponent(out Block block))
                {
                    _drill.OnContact(block);
                }
            }
        }
    }
}