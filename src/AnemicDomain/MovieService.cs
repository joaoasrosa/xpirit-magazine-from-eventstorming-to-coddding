using System.Collections.Generic;

namespace AnemicDomain
{
    public class MovieService
    {
        private readonly MovieRepository movieRepository;

        public MovieService(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public List<Seat> ReserveSeats(int numberOfSeats, string mvNaam)
        {
            Movie movie = movieRepository.FindByName(mvNaam);
            List<Seat> avlbSeats = FindSeats(movie, numberOfSeats);
            if (avlbSeats != null)
            {
                // Gets the row of seats and adds the new available seats
                movie.Seats[avlbSeats[0].RowNumber].AddRange(avlbSeats);
                movieRepository.Save(movie);
                return avlbSeats;
            }

            return new List<Seat>();
        }

        private List<Seat> FindSeats(Movie movie, int numberOfSeat)
        {
            foreach (string row in movie.Rows)
            {
                List<Seat> seats = DoesRowHaveEnoughSeats(movie, row, numberOfSeat);
                if (seats != null)
                {
                    return seats;
                }
            }

            return new List<Seat>();
        }

        private List<Seat> DoesRowHaveEnoughSeats(Movie movie, string row, int numberOfSeat)
        {
            var seats = new List<Seat>();

            for (int i = 0; i < movie.NumberOfSeatsPerRow - numberOfSeat; i++)
            {
                bool seatsAvailable = true;
                for (int o = 0; o < numberOfSeat; o++)
                {
                    if (!movie.Seats.ContainsKey(int.Parse(row)))
                    {
                        seatsAvailable = false;
                        movie.Seats.Add(int.Parse(row), new List<Seat> {new Seat {RowNumber = int.Parse(row)}});
                        seats.Add(new Seat {RowNumber = int.Parse(row)});
                    }
                    else if(movie.Seats.ContainsKey(int.Parse(row)))
                    {
                        var rowSeats = movie.Seats[int.Parse(row)];
                        if (rowSeats.Count + numberOfSeat <= movie.NumberOfSeatsPerRow)
                        {
                            seatsAvailable = false;

                            for (int j = o; j < numberOfSeat; j++)
                            {
                                rowSeats.Add(new Seat{RowNumber = int.Parse(row)});
                                seats.Add(new Seat {RowNumber = int.Parse(row)});
                            }
                        }
                    }

                    if (seats.Count == numberOfSeat)
                        return seats;
                }
            }

            return seats;
        }
    }
}