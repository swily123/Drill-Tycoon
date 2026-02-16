using UnityEngine;
using Upgrades;

namespace DrillSystem
{
    public class DrillScaler : LevelableEntity
    {
        [SerializeField] private float _startScale;
        
        private const float PositionFactor = 2f;
        private const float PositionOffsetZ = -5f;
        
        private Transform _transform;

        private void Awake()
        {
            StartValue = _startScale;
            _transform = transform;
        }

        public override void Upgrade(float scale)
        {
            if (scale < 0)
                throw new System.ArgumentOutOfRangeException(nameof(scale), scale, $"{nameof(scale)} cannot be negative");
            
            Scale(scale);
            base.Upgrade(scale);
        }

        private void Scale(float scale)
        {
            if (_transform == null)
                return;
            
            _transform.localScale = new Vector3(scale, scale, scale);
            _transform.localPosition = new Vector3(
                _transform.localPosition.x,
                _transform.localPosition.y,
                PositionOffsetZ - scale / PositionFactor
            );
        }
    }
}