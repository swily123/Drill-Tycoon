using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryViewUI : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private string _symbol;
        
        private int _maxBlocksCount;
        
        private void OnEnable()
        {
            _inventory.OnMaxCountChanged += ChangeMaxCount;
            _inventory.OnCountChanged += ChangeText;
        }

        private void OnDisable()
        {
            _inventory.OnMaxCountChanged -= ChangeMaxCount;
            _inventory.OnCountChanged -= ChangeText;
        }

        private void ChangeText(int count)
        {
            if (count < 0)
                return;
            
            _textField.text = count + _symbol + _maxBlocksCount;
            _slider.value = count;
        }

        private void ChangeMaxCount(int count)
        {
            if (count < 0)
                return;
            
            _maxBlocksCount = count;
            _slider.maxValue = _maxBlocksCount;
        }
    }
}