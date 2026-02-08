using UnityEngine;

namespace Player
{
    public class PlayerEconomic : MonoBehaviour
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private PlayerEconomicView _view;
        
        private int _money;
        //private int _crystals;

        private void OnEnable()
        {
            _shop.ItemPurchased += IncreaseMoney;
        }

        private void OnDisable()
        {
            _shop.ItemPurchased -= IncreaseMoney;
        }
        
        private void IncreaseMoney(int itemCost)
        {
            if (itemCost <= 0)
            {
                return;
            }
            
            _money += itemCost;
            _view.UpdateView(_money);
        }
    }
}