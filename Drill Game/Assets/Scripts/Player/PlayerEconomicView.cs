using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerEconomicView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        public void UpdateView(int money)
        {
            _moneyText.text = money.ToString();
        }
    }
}