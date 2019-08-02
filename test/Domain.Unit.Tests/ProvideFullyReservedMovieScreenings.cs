namespace Domain.Unit.Tests
{
    internal class ProvideFullyReservedMovieScreenings : IProvideMovieScreenings
    {
        public MovieScreening FindMovieScreening(uint movieScreeningId)
        {
            var movieScreening = new MovieScreening(5, 5);
            movieScreening.ReserveSeats(new ReserveSeats(25));
            return movieScreening;
        }
    }
}