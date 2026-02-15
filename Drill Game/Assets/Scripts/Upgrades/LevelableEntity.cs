using UnityEngine;

namespace Upgrades
{
    public abstract class LevelableEntity : MonoBehaviour
    {
        public int Level { get; private set; } = 1;

        public virtual void Upgrade(int value) 
        {
            Level++;
        }
    }
}