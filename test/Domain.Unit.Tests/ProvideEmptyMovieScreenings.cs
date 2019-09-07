namespace Domain.Unit.Tests
{
    internal class ProvideEmptyMovieScreenings : IProvideMovieScreenings
    {
        public MovieScreening FindMovieScreening(uint movieScreeningId)
        {
            return MovieScreening.CreateFrom(movieScreeningId, 5, 5);
        }
    }
}