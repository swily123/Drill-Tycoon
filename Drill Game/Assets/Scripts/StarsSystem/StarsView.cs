using UnityEngine;

namespace StarsSystem
{
    public class StarsView : MonoBehaviour
    {
        [SerializeField] private Star[] _stars = new Star[CountStars];

        private const int CountStars = 3;
        private const int FirstStarIndex = 0;
        private const int SecondStarIndex = 1;
        private const int ThirdStarIndex = 2;

        private const float FirstStarPercent = 50f;
        private const float SecondStarPercent = 70f;
        private const float ThirdStarPercent = 100f;

        private int _index;

        private void Awake()
        {
            HideAllStars();
        }

        private void OnValidate()
        {
            CheckStarsCount();
        }

        public void ShowStars(float percent)
        {
            if (CheckStarsCount())
                return;
            
            if (_stars[FirstStarIndex].IsHiding && percent >= FirstStarPercent)
            {
                _stars[FirstStarIndex].Show();
            }

            if (_stars[SecondStarIndex].IsHiding && percent >= SecondStarPercent)
            {
                _stars[SecondStarIndex].Show();
            }

            if (_stars[ThirdStarIndex].IsHiding && percent >= ThirdStarPercent)
            {
                _stars[ThirdStarIndex].Show();
            }
        }

        private void HideAllStars()
        {
            foreach (Star star in _stars)
            {
                star.Hide();
            }
        }

        private bool CheckStarsCount()
        {
            bool isCountMatches = _stars.Length != CountStars;
            
            if (_stars.Length != CountStars)
            {
                Debug.LogError($"{nameof(StarsView)} need {CountStars} stars");
                _stars = new Star[CountStars];
            }

            return isCountMatches;
        }
    }
}