using System.Collections.Generic;
using Value;

namespace Domain
{
    public class MovieScreeningId : ValueType<MovieScreeningId>
    {
        private readonly uint _movieScreeningId;

        private MovieScreeningId(uint movieScreeningId)
        {
            _movieScreeningId = movieScreeningId;
        }

        public static implicit operator uint(MovieScreeningId movieScreeningId)
        {
            return movieScreeningId._movieScreeningId;
        }

        public static explicit operator MovieScreeningId(uint movieScreeningId)
        {
            return new MovieScreeningId(movieScreeningId);
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object>() {_movieScreeningId};
        }
    }
}