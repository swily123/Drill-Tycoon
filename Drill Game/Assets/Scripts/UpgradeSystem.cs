using Planes;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private PlaneButton _button;
    [SerializeField] private Transform _upgradePanelUI;
    
    private bool _isActive;

    private void Awake()
    {
        _isActive = false;
        ToggleButton();
    }

    private void OnEnable()
    {
        _button.Clicked += ToggleButton;
        _button.Released += ToggleButton;
    }

    private void OnDisable()
    {
        _button.Clicked -= ToggleButton;
        _button.Released -= ToggleButton;
    }

    private void ToggleButton()
    {
        _upgradePanelUI.gameObject.SetActive(_isActive);
        _isActive = !_isActive;
    }
}