namespace InventorySystem
{
    public class Inventory
    {
        public int CountBlocks { get; private set; }

        private readonly int _maxBlocksCount;
    
        public Inventory(int maxBlocksCount)
        {
            _maxBlocksCount = maxBlocksCount;
            CountBlocks = 0;
        }

        public bool IsFree => CountBlocks < _maxBlocksCount;
    
        public void AddBlock()
        {
            if (IsFree)
            {
                CountBlocks++;
            }
        }
    }
}