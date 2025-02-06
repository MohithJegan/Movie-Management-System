using MovieManagementSystem.Models;

namespace MovieManagementSystem.Interfaces
{
    public interface IMovieService
    {
        // base CRUD
        Task<IEnumerable<MovieDto>> ListMovies();

        Task<MovieDto?> FindMovie(int id);

        Task<ServiceResponse> UpdateMovie(MovieDto movieDto);

        Task<ServiceResponse> AddMovie(MovieDto movieDto);

        Task<ServiceResponse> DeleteMovie(int id);

        // related methods

        Task<IEnumerable<MovieDto>> ListMoviesForActor(int id);

        Task<IEnumerable<MovieDto>> ListMoviesForStudio(int id);

        Task<ServiceResponse> LinkMovieToActor(int movieId, int actorId);

        Task<ServiceResponse> UnlinkMovieFromActor(int movieId, int actorId);
    }
}
