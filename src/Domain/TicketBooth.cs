using System;

namespace Domain
{
    public class TicketBooth
    {
        private readonly IMovieScreeningRepository _movieScreeningRepository;

        public TicketBooth(IMovieScreeningRepository movieScreeningRepository)
        {
            _movieScreeningRepository = movieScreeningRepository ?? throw new ArgumentNullException(nameof(movieScreeningRepository));
        }

        public void ReserveSeats(ReserveSeats reserveSeats)
        {
            throw new System.NotImplementedException();
        }
    }
}