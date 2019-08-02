using System.Collections.Generic;

namespace Domain
{
    public class MovieScreening
    {
        private readonly IDictionary<int, Row> _rows;

        public MovieScreening(int numberOfRows, int seatsPerRow)
        {
            _rows = new SortedDictionary<int, Row>();

            for (var rowNumber = 1; rowNumber <= numberOfRows; rowNumber++)
            {
                var row = new Row(rowNumber, seatsPerRow);
                _rows.Add(rowNumber, row);
            }
        }

        public SeatsReserved ReserveSeats(ReserveSeats reserveSeats)
        {
            foreach (var row in _rows)
            {
                if(!row.Value.HasAvailableSeats(reserveSeats.SeatsToBeReserved))
                    continue;
                
                
            }
        }
    }
}