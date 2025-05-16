namespace MineSweeperClasses
{
    public class Cell
    {
        public bool HasBomb { get; set; }
        public int BombNeighbors { get; set; }
        public bool HasReward { get; set; }

        public Cell()
        {
            HasBomb = false;
            BombNeighbors = 0;
            HasReward = false;
        }
    }
}
