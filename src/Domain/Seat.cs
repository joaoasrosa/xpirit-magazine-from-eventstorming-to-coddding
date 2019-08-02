namespace Domain
{
    internal class Seat
    {
        private readonly int _rowNumber;
        private readonly int _seatNumber;
        private readonly SeatStatus _seatStatus;

        internal Seat(int rowNumber, int seatNumber, SeatStatus seatStatus)
        {
            _rowNumber = rowNumber;
            _seatNumber = seatNumber;
            _seatStatus = seatStatus;
        }

        internal bool IsAvailable => _seatStatus == SeatStatus.Free;
    }
}