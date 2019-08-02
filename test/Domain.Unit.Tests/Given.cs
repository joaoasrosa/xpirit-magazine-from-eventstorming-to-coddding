namespace Domain.Unit.Tests
{
    internal static class Given
    {
        internal static class A
        {
            internal static TicketBooth FullyReservedMovieScreening()
            {
                var ticketBooth = new TicketBooth(new ProvideFullyReservedMovieScreenings());
                return ticketBooth;
            }
        }
    }
}