using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    internal class Row
    {
        private IReadOnlyList<Seat> _seats;

        internal Row(int rowNumber, int seatsPerRow)
        {
            var seats = new List<Seat>(seatsPerRow);

            for (var seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
            {
                seats.Add(Seat.CreateAvailableSeat(rowNumber, seatNumber));
            }

            _seats = seats;
        }

        internal bool HasAvailableSeats(uint seatsToBeReserved)
        {
            var numberOfAvailableSeats = _seats.Count(seat => seat.IsAvailable);

            return numberOfAvailableSeats >= seatsToBeReserved;
        }

        internal void ReserveSeats(uint seatsToBeReserved)
        {
            var seats = new List<Seat>(_seats.Count);
            var reservedSeats = 0;
            
            foreach (var seat in _seats)
            {
                if(reservedSeats < seatsToBeReserved && seat.IsAvailable)
                {
                    seats.Add(Seat.CreateReservedSeat(seat.RowNumber, seat.SeatNumber));
                    reservedSeats++;
                }
                else
                {
                    seats.Add(Seat.CreateFromSeat(seat));
                }
            }
            
            if (reservedSeats != seatsToBeReserved)
                throw new SeatsNotAvailable();

            _seats = seats;
        }
    }
}