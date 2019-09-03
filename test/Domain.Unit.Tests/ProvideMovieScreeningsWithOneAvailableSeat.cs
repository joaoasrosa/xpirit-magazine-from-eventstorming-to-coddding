namespace Domain.Unit.Tests
{
    internal class ProvideMovieScreeningsWithOneAvailableSeat : IProvideMovieScreenings
    {
        public MovieScreening FindMovieScreening(uint movieScreeningId)
        {
            var movieScreening = MovieScreening.CreateFrom(movieScreeningId, 5, 5);
            movieScreening.ReserveSeats(new ReserveSeats(movieScreeningId, 5));
            movieScreening.ReserveSeats(new ReserveSeats(movieScreeningId, 5));
            movieScreening.ReserveSeats(new ReserveSeats(movieScreeningId, 5));
            movieScreening.ReserveSeats(new ReserveSeats(movieScreeningId, 5));
            movieScreening.ReserveSeats(new ReserveSeats(movieScreeningId, 4));
            return movieScreening;
        }
    }
}