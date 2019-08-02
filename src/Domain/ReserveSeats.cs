namespace Domain
{
    public class ReserveSeats
    {
        public uint SeatsToBeReserved { get; }
        public uint MovieScreeningId { get; }

        public ReserveSeats(uint movieScreeningId, uint seatsToBeReserved)
        {
            MovieScreeningId = movieScreeningId;
            SeatsToBeReserved = seatsToBeReserved;
        }
    }
}