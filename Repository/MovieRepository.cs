using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        void IMovieRepository.AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.DeleteMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        List<Movie> IMovieRepository.GetMovies()
        {
            throw new NotImplementedException();
        }

        void IMovieRepository.UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
