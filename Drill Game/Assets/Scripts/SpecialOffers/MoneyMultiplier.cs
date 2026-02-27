using UnityEngine;

namespace SpecialOffers
{
    public class MoneyMultiplier : SpecialOffer
    {
        [SerializeField] private Shop _shop;

        private const float ActiveMultiplier = 2f;
        private const float DefaultMultiplier = 1f;

        protected override void OnActivated()
        {
            _shop.SetCostMultiplier(ActiveMultiplier);
        }

        protected override void Deactivate()
        {
            _shop.SetCostMultiplier(DefaultMultiplier);
        }
    }
}