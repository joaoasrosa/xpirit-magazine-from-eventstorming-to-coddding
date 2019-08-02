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
        }
    }
}