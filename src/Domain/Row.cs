using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    internal class Row
    {
        private readonly IReadOnlyList<Seat> _seats;

        internal Row(int rowNumber, int seatsPerRow)
        {
            var seats = new List<Seat>(seatsPerRow);

            for (var seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
            {
                seats.Add(new Seat(rowNumber, seatNumber, SeatStatus.Free));
            }

            _seats = seats;
        }

        internal bool HasAvailableSeats(uint seatsToBeReserved)
        {
            var numberOfAvailableSeats = _seats.Count(seat => seat.IsAvailable);

            return numberOfAvailableSeats >= seatsToBeReserved;
        }
    }
}