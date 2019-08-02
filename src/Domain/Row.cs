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
                seats.Add(new Seat(rowNumber, seatNumber, SeatStatus.Free));
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
                if(seat.IsAvailable)
                {
                    seats.Add(new Seat(seat.RowNumber, seat.SeatNumber, SeatStatus.Reserved));
                    reservedSeats++;
                }
                else
                {
                    seats.Add(new Seat(seat.RowNumber, seat.SeatNumber, seat.SeatStatus));
                }

                if (reservedSeats == seatsToBeReserved)
                    break;
            }
            
            if (reservedSeats != seatsToBeReserved)
                throw new SeatsNotAvailable();

            _seats = seats;
        }
    }
}