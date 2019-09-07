using System;

namespace Domain
{
    public class TicketBooth
    {
        private readonly IProvideMovieScreenings _movieScreeningRepository;

        public TicketBooth(IProvideMovieScreenings movieScreeningRepository)
        {
            _movieScreeningRepository = movieScreeningRepository ??
                                        throw new ArgumentNullException(nameof(movieScreeningRepository));
        }

        public SeatsReserved ReserveSeats(ReserveSeats reserveSeats)
        {
            if (reserveSeats.SeatsToBeReserved > 8)
                throw new MaximumEightSeatsPerCustomer();

            var movieScreening = _movieScreeningRepository.FindMovieScreening(reserveSeats.MovieScreeningId);
            return movieScreening.ReserveSeats(reserveSeats);
        }
    }
}