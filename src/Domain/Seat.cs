using System.Collections.Generic;
using Value;

namespace Domain
{
    internal class Seat : ValueType<Seat>
    {
        private readonly SeatStatus _seatStatus;
        internal RowNumber RowNumber { get; }
        internal int SeatNumber { get; }

        private Seat(RowNumber rowNumber, int seatNumber, SeatStatus seatStatus)
        {
            _seatStatus = seatStatus;
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object>() {RowNumber, SeatNumber};
        }

        internal bool IsAvailable => _seatStatus == SeatStatus.Available;

        internal static Seat CreateAvailableSeat(RowNumber rowNumber, int seatNumber)
        {
            return new Seat(rowNumber, seatNumber, SeatStatus.Available);
        }

        internal static Seat CreateReservedSeat(RowNumber rowNumber, int seatNumber)
        {
            return new Seat(rowNumber, seatNumber, SeatStatus.Reserved);
        }

        internal static Seat CreateFromSeat(Seat seat)
        {
            return new Seat(seat.RowNumber, seat.SeatNumber, seat._seatStatus);
        }
    }
}