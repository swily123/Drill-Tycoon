using System.Globalization;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerEconomicView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private string _coinSymbol;
        
        private void OnEnable()
        {
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChanged += UpdateView;
        }

        private void OnDisable()
        {
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChanged -= UpdateView;
        }

        private void UpdateView()
        {
            _moneyText.text = PlayerEconomic.Instance.Money.ToString(CultureInfo.CurrentCulture) + _coinSymbol;
        }
    }
}