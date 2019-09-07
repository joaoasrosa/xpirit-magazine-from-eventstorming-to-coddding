using System.Linq;

namespace AnemicDomain
{
    public class MovieRepository
    {
        private readonly MovieContext _movieContext;

        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public Movie FindByName(string mvNaam)
        {
            return _movieContext.Movies.FirstOrDefault(x => x.Name.Equals(mvNaam));
        }

        public void Save(Movie movie)
        {
            if (_movieContext.Movies.Any(x => x.Id.Equals(movie.Id)))
                _movieContext.Movies.Update(movie);
            else
                _movieContext.Movies.Add(movie);

            _movieContext.SaveChanges();
        }
    }
}