using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public class UpgradeUI : MonoBehaviour // TODO класс чтобы прятать и красить кнопки в зависимости от денег
    {
        [Header("Buttons")]
        [SerializeField] private Button _movementUpgrade;
        [SerializeField] private Button _inventoryUpgrade;
        [SerializeField] private Button _drillSizeUpgrade;
        [SerializeField] private Button _drillSpeedUpgrade;
        
    }
}