using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AnemicDomain.Unit.Tests
{
    public class MovieServiceTests
    {
        [Fact]
        public void IfMovieScreeningIsEmpty_ReserveSeats()
        {
            const int numberOfSeatsMagicValue = 2;

            var options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryTestMovieDatabase")
                .Options;

            using (var context = new MovieContext(options))
            {
                var movieRepository = new MovieRepository(context);
                movieRepository.Save(
                    new Movie
                    {
                        Id = 1,
                        Name = "Matrix",
                        NumberOfSeatsPerRow = 5,
                        Rows = new List<string> {"1", "2", "3", "4", "5"},
                        Seats = new Dictionary<int, List<Seat>>()
                    }
                );
            }

            using (var context = new MovieContext(options))
            {
                var movieRepository = new MovieRepository(context);
                var movieService = new MovieService(movieRepository);

                var seats = movieService.ReserveSeats(numberOfSeatsMagicValue, "Matrix");

                Assert.Equal(numberOfSeatsMagicValue, seats.Count);
            }
        }
    }
}