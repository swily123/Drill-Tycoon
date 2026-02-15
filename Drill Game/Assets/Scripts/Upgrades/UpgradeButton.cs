using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private UpgradeEngine _upgradeEngine;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private UpgradeUI _upgradeUI;
        
        private void OnEnable()
        {
            _upgradeEngine.DisablingButton += Disable;
            _upgradeButton.onClick.AddListener(Upgrade);

            if (PlayerEconomic.Instance != null)
            {
                SetRepresentation();
                PlayerEconomic.Instance.OnMoneyChanged += SetRepresentation;
            }
        }

        private void OnDisable()
        {
            _upgradeEngine.DisablingButton -= Disable;
            _upgradeButton.onClick.RemoveListener(Upgrade);
            
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChanged -= SetRepresentation;
        }

        private void Upgrade()
        {
            _upgradeEngine.TryBuyUpgrade();
        }

        private void SetRepresentation()
        {
            bool canBuy = _upgradeEngine.CanBuyUpgrade();
            _upgradeButton.interactable = canBuy;
            _upgradeUI.Colorize(canBuy);
        }

        private void Disable()
        {
            Destroy(_upgradeButton.gameObject);
            OnDisable();
            Destroy(this);
        }
    }
}