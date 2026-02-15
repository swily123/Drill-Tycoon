using System.Collections;
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
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        
        public void Colorize(bool isSuccessful)
        {
            _buttonText.color = isSuccessful ? _successfulColorButton : _unsuccessfulColorButton;
            _descriptionText.color = isSuccessful ? _successfulColorText : _unsuccessfulColorText;
        }
    }
}