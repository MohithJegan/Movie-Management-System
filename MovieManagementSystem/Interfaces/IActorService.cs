using MovieManagementSystem.Models;

namespace MovieManagementSystem.Interfaces
{
    public interface IActorService
    {
        // base CRUD
        Task<IEnumerable<ActorDto>> ListActors();

        Task<ActorDto?> FindActor(int id);

        Task<ServiceResponse> UpdateActor(ActorDto actorDto);

        Task<ServiceResponse> AddActor(ActorDto actorDto);

        Task<ServiceResponse> DeleteActor(int id);

        // related methods

        Task<IEnumerable<ActorDto>> ListActorsForMovie(int id);

 
    }
}
