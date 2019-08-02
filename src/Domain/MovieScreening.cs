using System.Collections.Generic;

namespace Domain
{
    public class MovieScreening
    {
        public uint MovieScreeningId { get; }
        
        private readonly IDictionary<int, Row> _rows;

        public MovieScreening(uint movieScreeningId, int numberOfRows, int seatsPerRow)
        {
            MovieScreeningId = movieScreeningId;
            _rows = new SortedDictionary<int, Row>();

            for (var rowNumber = 1; rowNumber <= numberOfRows; rowNumber++)
            {
                var row = new Row(rowNumber, seatsPerRow);
                _rows.Add(rowNumber, row);
            }
        }

        public SeatsReserved ReserveSeats(ReserveSeats reserveSeats)
        {
            Row rowWithAvailableSeats = null;
            
            foreach (var row in _rows)
            {
                if(!row.Value.HasAvailableSeats(reserveSeats.SeatsToBeReserved))
                    continue;

                rowWithAvailableSeats = row.Value;
            }
            
            if(rowWithAvailableSeats is null)
                throw new SeatsNotAvailable();

            rowWithAvailableSeats.ReserveSeats(reserveSeats.SeatsToBeReserved);
            
            return new SeatsReserved(reserveSeats.SeatsToBeReserved);
        }
    }
}