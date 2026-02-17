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

            if (block.IsDieOnDamage(_speed) == false) //TODO AddForce, откинуть назад если не смог сломать
            {
                Debug.Log("Block Hit");
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