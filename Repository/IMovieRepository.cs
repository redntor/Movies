using Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Repository
{
    interface IMovieRepository
    {
        List<Movie> GetMovies();
        void UpdateMovie(Movie movie);
        void AddMovie(Movie movie);
        void DeleteMovie(int movieId);
    }
}
