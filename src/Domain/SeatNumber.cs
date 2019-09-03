using System.Collections.Generic;
using Value;

namespace Domain
{
    internal class SeatNumber : ValueType<SeatNumber>
    {
        private readonly int _seatNumber;

        private SeatNumber(int seatNumber)
        {
            _seatNumber = seatNumber;
        }

        public static implicit operator SeatNumber(int seatNumber)
        {
            return new SeatNumber(seatNumber);
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object> {_seatNumber};
        }
    }
}