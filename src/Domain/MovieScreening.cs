using System.Collections.Generic;

namespace Domain
{
    public class MovieScreening
    {
        private readonly IDictionary<int, IReadOnlyList<Seat>> _rows;

        public MovieScreening(int numberOfRows, int seatsPerRow)
        {
            _rows = new SortedDictionary<int, IReadOnlyList<Seat>>();

            for (var rowNumber = 1; rowNumber <= numberOfRows; rowNumber++)
            {
                var row = new List<Seat>(seatsPerRow);

                for (var seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
                {
                    row.Add(new Seat(rowNumber, seatNumber, SeatStatus.Reserved));
                }
                
                _rows.Add(rowNumber, row);
            }
        }

        public SeatsReserved ReserveSeats(ReserveSeats reserveSeats)
        {
            throw new System.NotImplementedException();
        }
    }
}