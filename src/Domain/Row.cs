using System.Collections.Generic;
using System.Linq;
using Value;

namespace Domain
{
    internal class Row : ValueType<Row>
    {
        private readonly IList<Seat> _seats;

        internal RowNumber RowNumber { get; }

        private Row(RowNumber rowNumber, int seatsPerRow)
        {
            RowNumber = rowNumber;

            var seats = new List<Seat>(seatsPerRow);

            for (var seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
            {
                seats.Add(Seat.CreateAvailableSeat(rowNumber, seatNumber));
            }

            _seats = seats;
        }

        private Row(RowNumber rowNumber, IEnumerable<Seat> seats)
        {
            RowNumber = rowNumber;
            
            _seats = new List<Seat>(seats);
        }

        internal bool HasAvailableSeats(uint seatsToBeReserved)
        {
            var numberOfAvailableSeats = _seats.Count(seat => seat.IsAvailable);

            return numberOfAvailableSeats >= seatsToBeReserved;
        }

        internal Row ReserveSeats(uint seatsToBeReserved)
        {
            var seats = new List<Seat>(_seats.Count);
            var reservedSeats = 0;

            foreach (var seat in _seats)
            {
                if (reservedSeats < seatsToBeReserved && seat.IsAvailable)
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

            return new Row(RowNumber, seats);
        }

        internal static Row CreateNewRow(int rowNumber, int seatsPerRow)
        {
            return new Row(rowNumber, seatsPerRow);
        }

        internal static Row CreateFromRow(Row row)
        {
            return new Row(row.RowNumber, row._seats);
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object>() {RowNumber};
        }
    }
}