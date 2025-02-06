using MovieManagementSystem.Models;

namespace MovieManagementSystem.Interfaces
{
    public interface IStudioService
    {
        // base CRUD
        Task<IEnumerable<StudioDto>> ListStudios();

        Task<StudioDto?> FindStudio(int id);

        Task<ServiceResponse> UpdateStudio(StudioDto studioDto);

        Task<ServiceResponse> AddStudio(StudioDto studioDto);

        Task<ServiceResponse> DeleteStudio(int id);

        // related methods

        Task<IEnumerable<StudioDto>> ListStudioForMovie(int id);



    }
}
