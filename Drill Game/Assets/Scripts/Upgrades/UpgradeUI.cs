using System.Globalization;
using TMPro;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeUI : MonoBehaviour
    {
        [Header("Colors")]
        [SerializeField] private Color _successfulColorButton;
        [SerializeField] private Color _unsuccessfulColorButton;
        [SerializeField] private Color _successfulColorText;
        [SerializeField] private Color _unsuccessfulColorText;
        
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _button;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _maxLevel;
        
        [Header("Texts fields")]
        [SerializeField] private string _levelText;
        [SerializeField] private string _descriptionText;
        [SerializeField] private string _buttonText;

        private void Awake()
        {
            SetMaxLevel(false);
        }

        public void Colorize(bool isSuccessful)
        {
            _button.color = isSuccessful ? _successfulColorButton : _unsuccessfulColorButton;
            _description.color = isSuccessful ? _successfulColorText : _unsuccessfulColorText;
        }
        
        public void SetLevelText(int level)
        {
            _level.text = _levelText + level;
        }
        
        public void SetDescriptionText(float firstValue, float secondValue)
        {
            _description.text = firstValue.ToString("0.##", CultureInfo.InvariantCulture) +  _descriptionText + secondValue.ToString("0.##", CultureInfo.InvariantCulture);
        }
        
        public void SetDescriptionText(float value)
        {
            _description.text = value.ToString("0.##", CultureInfo.InvariantCulture);
        }
        
        public void SetButtonText(int upgradeCost)
        {
            _button.text = upgradeCost + _buttonText;
        }

        public void SetMaxLevel(bool active = true)
        {
            _maxLevel.gameObject.SetActive(active);
        }
    }
}