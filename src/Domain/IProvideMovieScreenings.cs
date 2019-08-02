namespace Domain
{
    public interface IProvideMovieScreenings
    {
        MovieScreening FindMovieScreening(uint movieScreeningId);
    }
}