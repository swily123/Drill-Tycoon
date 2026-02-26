using UnityEngine;

namespace Blocks
{
    public class BlocksCounter : MonoBehaviour
    {
        [SerializeField] private BlocksCounterView _blocksCounterView;
        [SerializeField] private int _maxBlocksCount;
        
        private int _blocksCount;
        private const float MaxPercent = 100f;

        private void Awake()
        {
            _blocksCount = 0;
        }

        public void OnBlockDie()
        {
            _blocksCount++;
            _blocksCounterView.UpdateView(_blocksCount * MaxPercent / _maxBlocksCount);
        }
    }
}