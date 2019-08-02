namespace Domain.Unit.Tests
{
    internal class ProvideFullyReservedMovieScreenings : IProvideMovieScreenings
    {
        public MovieScreening FindMovieScreening(uint movieScreeningId)
        {
            var movieScreening = new MovieScreening(5, 5);

            return movieScreening;
        }
    }
}