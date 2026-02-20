using Blocks;
using UnityEngine;

namespace DrillSystem
{
    public class DrillCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Drill _drill;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out Block block))
            {
                block.MakeSolid(block.IsDieOnDamage(_drill.CurrentSpeed));
            }
        }
    }
}