public class Inventory
{
    private readonly int _maxBlocksCount;
    private int _countBlocks;
    
    public Inventory(int maxBlocksCount)
    {
        _maxBlocksCount = maxBlocksCount;
        _countBlocks = 0;
    }

    public bool IsFree => _countBlocks < _maxBlocksCount;
    
    public void AddBlock()
    {
        if (IsFree)
        {
            _countBlocks++;
        }
    }
}