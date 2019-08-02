namespace Domain
{
    public class ReserveSeats
    {
        public uint SeatsToBeReserved { get; }

        public ReserveSeats(uint seatsToBeReserved)
        {
            SeatsToBeReserved = seatsToBeReserved;
        }
    }
}