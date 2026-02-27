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

        public event Action<float> OnUpgraded;
        
        public float CurrentSpeed => _speed;
        
        private bool _isImprovementActive;
        
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
        
            base.Upgrade(speed);

            if (_isImprovementActive)
                OnUpgraded?.Invoke(speed);
            else
                _speed = speed;
        }

        public void SetOfferSpeed(float speed, bool isImprovementActive)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed), speed, $"{nameof(speed)} cannot be negative");

            _speed = speed;
            _isImprovementActive = isImprovementActive;
        }
    }
}