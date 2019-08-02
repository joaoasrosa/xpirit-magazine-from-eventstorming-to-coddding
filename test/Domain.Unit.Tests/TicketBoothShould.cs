using FluentAssertions;
using Xunit;

namespace Domain.Unit.Tests
{
    public class TicketBoothShould
    {
        [Fact]
        public void Return_SeatsNotAvailable_when_MovieScreening_has_all_its_seats_already_reserved()
        {
            var ticketBooth = Given.A.FullyReservedMovieScreening();

            var seatsNotAvailable = Record.Exception(() => ticketBooth.ReserveSeats(new ReserveSeats(1,2)));

            seatsNotAvailable.Should().BeOfType<SeatsNotAvailable>();
        }
    }
}