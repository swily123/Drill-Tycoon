using UnityEngine;

namespace Upgrades
{
    public abstract class LevelableEntity : MonoBehaviour
    {
        public int Level { get; private set; } = 1;
        public float StartValue { get; protected set; }
        
        public virtual void Upgrade(float value) 
        {
            Level++;
        }
    }
}