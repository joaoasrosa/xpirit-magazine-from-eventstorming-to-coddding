namespace Domain
{
    internal class Seat
    {
        internal int RowNumber { get; }
        internal int SeatNumber { get; }
        internal SeatStatus SeatStatus { get; }

        internal Seat(int rowNumber, int seatNumber, SeatStatus seatStatus)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            SeatStatus = seatStatus;
        }

        internal bool IsAvailable => SeatStatus == SeatStatus.Free;
    }
}