using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerEconomicView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private string _coinSymbol;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _minValueToActivateAnimation = 5;
        
        private void OnEnable()
        {
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChangedValue += UpdateView;
        }

        private void OnDisable()
        {
            if (PlayerEconomic.Instance != null)
                PlayerEconomic.Instance.OnMoneyChangedValue -= UpdateView;
        }

        private void UpdateView(float newValue)
        {
            float oldValue = PlayerEconomic.Instance.Money;
            _moneyText.DOKill();
            
            if (newValue - oldValue < _minValueToActivateAnimation)
            {
                _moneyText.text = newValue.ToString("0", CultureInfo.InvariantCulture) + _coinSymbol;
            }
            else
            {
                DOTween.To(
                    () => oldValue,
                    x => {
                        _moneyText.text = x.ToString("0", CultureInfo.InvariantCulture) + _coinSymbol;
                    },
                    newValue, _animationDuration
                ).SetEase(Ease.OutCubic);
            }
        }
    }
}