using System;

namespace Domain
{
    public class TicketBooth
    {
        private readonly IProvideMovieScreenings _movieScreeningRepository;

        public TicketBooth(IProvideMovieScreenings movieScreeningRepository)
        {
            _movieScreeningRepository = movieScreeningRepository ?? throw new ArgumentNullException(nameof(movieScreeningRepository));
        }

        public void ReserveSeats(ReserveSeats reserveSeats)
        {
            throw new System.NotImplementedException();
        }
    }
}