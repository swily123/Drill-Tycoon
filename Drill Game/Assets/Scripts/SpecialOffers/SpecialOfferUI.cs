using UnityEngine;
using UnityEngine.UI;

namespace SpecialOffers
{
    public class SpecialOfferUI : MonoBehaviour
    {
        [SerializeField] private SpecialOffer _specialOffer;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(ActivateOffer);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ActivateOffer);
        }

        private void ActivateOffer()
        {
            _specialOffer.Activate();
            _button.interactable = false;
        }
    }
}