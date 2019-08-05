using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Domain
{
    public class MovieScreening
    {
        public uint MovieScreeningId { get; }

        private IList<Row> _rows;

        public MovieScreening(uint movieScreeningId, int numberOfRows, int seatsPerRow)
        {
            MovieScreeningId = movieScreeningId;
            _rows = new List<Row>();

            for (var rowNumber = 1; rowNumber <= numberOfRows; rowNumber++)
            {
                var row = Row.CreateNewRow(rowNumber, seatsPerRow);
                _rows.Add(row);
            }
        }

        public SeatsReserved ReserveSeats(ReserveSeats reserveSeats)
        {
            var rows = new List<Row>();
            Row rowWithAvailableSeats = null;

            foreach (var row in _rows)
            {
                if (!(rowWithAvailableSeats is null) || !row.HasAvailableSeats(reserveSeats.SeatsToBeReserved))
                {
                    rows.Add(Row.CreateFromRow(row));
                    continue;
                }

                rowWithAvailableSeats = row;
            }

            if (rowWithAvailableSeats is null)
                throw new SeatsNotAvailable();

            rows.Add(rowWithAvailableSeats.ReserveSeats(reserveSeats.SeatsToBeReserved));

            _rows = rows.OrderBy(x=>x.RowNumber).ToList();

            return new SeatsReserved(reserveSeats.SeatsToBeReserved);
        }
    }
}