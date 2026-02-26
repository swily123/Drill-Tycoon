using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerEconomicView : MonoBehaviour
    {
        [SerializeField] private PlayerEconomic _playerEconomic;
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private string _coinSymbol;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _minValueToActivateAnimation = 5;
        
        private void OnEnable()
        {
            _playerEconomic.OnMoneyChangedValue += UpdateView;
        }

        private void OnDisable()
        {
            _playerEconomic.OnMoneyChangedValue -= UpdateView;
        }

        private void UpdateView(float oldValue, float newValue)
        {
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