using UnityEngine;

namespace Blocks
{
    public class Item : MonoBehaviour
    {
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}