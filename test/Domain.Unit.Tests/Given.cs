namespace Domain.Unit.Tests
{
    internal static class Given
    {
        internal static class A
        {
            internal static TicketBooth FullyReservedMovieScreening()
            {
                return new TicketBooth(new ProvideFullyReservedMovieScreenings());
            }

            internal static TicketBooth MovieScreeningWithOneAvailableSeat()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}