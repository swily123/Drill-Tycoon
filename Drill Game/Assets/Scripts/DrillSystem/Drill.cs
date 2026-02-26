using System;
using Blocks;
using Player;
using UnityEngine;
using Upgrades;

namespace DrillSystem
{
    public class Drill : LevelableEntity
    {
        [SerializeField] private BlocksCounter _blocksCounter;
        [SerializeField] private PlayerPhysics _player;
        [SerializeField] private float _speed;
        
        public float CurrentSpeed => _speed;
        
        private void Awake()
        {
            StartValue = _speed;
        }

        public void OnContact(Block block)
        {
            if (block.IsDieOnDamage(_speed) == false)
            {
                _blocksCounter.OnBlockDie();
            }
            
            block.TakeDamage(_speed);
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