using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private UpgradeEngine _upgradeEngine;
        [SerializeField] private Button _upgradeButton;

        private void OnEnable()
        {
            _upgradeEngine.DisablingButton += Disable;
            _upgradeButton.onClick.AddListener(Upgrade);

            if (PlayerEconomic.Instance != null)
            {
                SetInteractable();
                PlayerEconomic.Instance.OnMoneyChanged += SetInteractable;
            }
        }

        private void OnDisable()
        {
            _upgradeEngine.DisablingButton -= Disable;
            _upgradeButton.onClick.RemoveListener(Upgrade);
            
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChanged -= SetInteractable;
        }

        private void Upgrade()
        {
            _upgradeEngine.TryBuyUpgrade();
        }

        private void SetInteractable()
        {
            _upgradeButton.interactable = _upgradeEngine.CanBuyUpgrade();
        }

        private void Disable()
        {
            OnDisable();
            Destroy(_upgradeButton.gameObject);
        }
    }
}