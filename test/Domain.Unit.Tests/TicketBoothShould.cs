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

            var seatsNotAvailable = Record.Exception(() => ticketBooth.ReserveSeats(new ReserveSeats(1, 2)));

            seatsNotAvailable.Should().BeOfType<SeatsNotAvailable>(
                "there are no seats available for the movie screening"
            );
        }

        [Fact]
        public void Reserve_one_seat_when_MovieScreening_only_contains_one_available_seat()
        {
            var ticketBooth = Given.A.MovieScreeningWithOneAvailableSeat();

            var seatsReserved = ticketBooth.ReserveSeats(new ReserveSeats(1, 1));

            seatsReserved.NumberOfReservedSeats.Should().Be(
                1,
                "there we request the reservation of one seat, and the movie screening has one seat available"
            );
        }

        [Fact]
        public void Return_MaximumEightSeatsPerCustomer_when_tries_to_reserve_nine_seats()
        {
            var ticketBooth = Given.A.EmptyMovieScreening();

            var maximumEightSeatsPerCustomer = Record.Exception(() => ticketBooth.ReserveSeats(new ReserveSeats(1, 9)));

            maximumEightSeatsPerCustomer.Should().BeOfType<MaximumEightSeatsPerCustomer>(
                "a maximum of 8 seats can be reserved per customer"
            );
        }
    }
}