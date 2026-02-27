using System;
using DrillSystem;
using UnityEngine;

namespace SpecialOffers
{
    public class DrillSpeedOffer : SpecialOffer
    {
        [SerializeField] private Drill _drill;

        private const float SpeedMaximum = 100f;
        private float _originalSpeed;

        private void OnEnable()
        {
            _drill.OnUpgraded += UpdateOriginalSpeed;
        }

        private void OnDisable()
        {
            _drill.OnUpgraded -= UpdateOriginalSpeed;
        }

        protected override void OnActivated()
        {
            _originalSpeed = _drill.CurrentSpeed;
            _drill.SetOfferSpeed(SpeedMaximum, true);
        }

        protected override void Deactivate()
        {
            _drill.SetOfferSpeed(_originalSpeed, false);
        }
        
        private void UpdateOriginalSpeed(float speed)
        {
            _originalSpeed = speed;
        }
    }
}