using System.Collections.Generic;

namespace Domain
{
    internal class Row
    {
        private readonly IReadOnlyList<Seat> _seats;
        
        public Row(int rowNumber, int seatsPerRow)
        {
            var seats = new List<Seat>(seatsPerRow);

            for (var seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
            {
                seats.Add(new Seat(rowNumber, seatNumber, SeatStatus.Free));
            }

            _seats = seats;
        }
    }
}