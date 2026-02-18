using UnityEngine;
using UnityEngine.UI;

namespace StarsSystem
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _collectedStar;
        [SerializeField] private Sprite _notCollectedStar;

        public bool IsHiding { get; private set; } = true;
        
        public void Show()
        {
            _image.sprite = _collectedStar;
            IsHiding = false;
        }

        public void Hide()
        {
            _image.sprite = _notCollectedStar;
            IsHiding = true;
        }
    }
}