using StarsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Blocks
{
    public class BlocksCounterView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private StarsView _starsView;

        public void UpdateView(float percent)
        {
            _slider.value = percent;
            _starsView.ShowStars(percent);
        }
    }
}