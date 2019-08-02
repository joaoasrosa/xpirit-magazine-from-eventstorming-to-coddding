namespace Domain
{
    public class MovieScreening
    {
        private readonly uint _rows;
        private readonly uint _seatsPerRow;

        public MovieScreening(uint rows, uint seatsPerRow)
        {
            _rows = rows;
            _seatsPerRow = seatsPerRow;
        }
    }
}