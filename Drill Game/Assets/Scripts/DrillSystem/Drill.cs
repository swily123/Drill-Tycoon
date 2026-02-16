using System;
using Blocks;
using UnityEngine;
using Upgrades;

namespace DrillSystem
{
    public class Drill : LevelableEntity
    {
        [SerializeField] private float _speed;

        private void Awake()
        {
            StartValue = _speed;
        }

        public void OnContact(Block block)
        {
            block.TakeDamage(_speed);

            if (block != null) //TODO AddForce, откинуть назад если не смог сломать
            {
                Debug.Log("Block Hit");
            }
            else
            {
                Debug.Log("Block die");
            }
        }

        public override void Upgrade(float speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed), speed, $"{nameof(speed)} cannot be negative");
        
            _speed = speed;
            base.Upgrade(speed);
        }
    }
}