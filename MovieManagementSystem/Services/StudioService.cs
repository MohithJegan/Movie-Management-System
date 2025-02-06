
using MovieManagementSystem.Interfaces;
using MovieManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using MovieManagementSystem.Data;


namespace MovieManagementSystem.Services
{
    public class StudioService : IStudioService
    {
        private readonly ApplicationDbContext _context;

        // dependency injection of database context
        public StudioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudioDto>> ListStudios()
        {
            // all studios
            IEnumerable<Studio> Studios = await _context.Studios
                 .ToListAsync();
            List<StudioDto> StudioDtos = new List<StudioDto>();

            // foreach Studio record in database
            foreach (Studio Studio in Studios)
            {
                // create new instance of StudioDto, add to list
                StudioDtos.Add(new StudioDto()
                {
                    StudioID = Studio.StudioID,
                    StudioName = Studio.StudioName,
                    StudioCountry = Studio.StudioCountry,
                    StudioEstablishedYear = Studio.StudioEstablishedYear,
                    StudioCEO = Studio.StudioCEO,
                    StudioHeadquarter = Studio.StudioHeadquarter
                });
            }

            // return StudioDtos
            return StudioDtos;
        }

     
        public async Task<StudioDto?> FindStudio(int id)
        {
            // first or default async will get the first studio item matching the {id}
            var Studio = await _context.Studios.FirstOrDefaultAsync(s => s.StudioID == id);

            // no studio found
            if (Studio == null)
            {
                return null;
            }

            StudioDto StudioDto = new StudioDto()
            {
                StudioID = Studio.StudioID,
                StudioName = Studio.StudioName,
                StudioCountry = Studio.StudioCountry,
                StudioEstablishedYear = Studio.StudioEstablishedYear,
                StudioCEO = Studio.StudioCEO,
                StudioHeadquarter = Studio.StudioHeadquarter
            };
            return StudioDto;
        }

    
        public async Task<ServiceResponse> UpdateStudio(StudioDto studioDto)
        {
            ServiceResponse serviceResponse = new();

            // Create instance of Studio
            Studio studio = new Studio()
            {
                StudioID = Convert.ToInt32(studioDto.StudioID),
                StudioName = studioDto.StudioName,
                StudioCountry = studioDto.StudioCountry,
                StudioEstablishedYear = studioDto.StudioEstablishedYear,
                StudioCEO = studioDto.StudioCEO,
                StudioHeadquarter = studioDto.StudioHeadquarter
            };

            // flags that the object has changed
            _context.Entry(studio).State = EntityState.Modified;

            try
            {
                // SQL Equivalent: Update Studios set ... where StudioId={id}
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                serviceResponse.Status = ServiceResponse.ServiceStatus.Error;
                serviceResponse.Messages.Add("An error occurred updating the record");
                return serviceResponse;
            }

            serviceResponse.Status = ServiceResponse.ServiceStatus.Updated;
            return serviceResponse;
        }

        public async Task<ServiceResponse> AddStudio(StudioDto studioDto)
        {
            ServiceResponse serviceResponse = new();

            // Create instance of Studio
            Studio Studio = new Studio()
            {
                StudioID = studioDto.StudioID,
                StudioName = studioDto.StudioName,
                StudioCountry = studioDto.StudioCountry,
                StudioEstablishedYear = studioDto.StudioEstablishedYear,
                StudioCEO = studioDto.StudioCEO,
                StudioHeadquarter = studioDto.StudioHeadquarter
            };

            // SQL Equivalent: Insert into Studios (..) values (..)

            try
            {
                _context.Studios.Add(Studio);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Status = ServiceResponse.ServiceStatus.Error;
                serviceResponse.Messages.Add("There was an error adding the Studio.");
                serviceResponse.Messages.Add(ex.Message);
            }

            serviceResponse.Status = ServiceResponse.ServiceStatus.Created;
            serviceResponse.CreatedId = Studio.StudioID;
            return serviceResponse;
        
        }

        public async Task<ServiceResponse> DeleteStudio(int id)
        {
            ServiceResponse response = new();

            // Studio Item must exist in the first place
            var Studio = await _context.Studios.FindAsync(id);

            if (Studio == null)
            {
                response.Status = ServiceResponse.ServiceStatus.NotFound;
                response.Messages.Add("Studio cannot be deleted because it does not exist.");
                return response;
            }

            try
            {
                _context.Studios.Remove(Studio);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.Status = ServiceResponse.ServiceStatus.Error;
                response.Messages.Add("Error encountered while deleting the studio");
                return response;
            }

            response.Status = ServiceResponse.ServiceStatus.Deleted;

            return response;

        }

        public async Task<IEnumerable<StudioDto>> ListStudioForMovie(int id)
        {
            // join StudioMovie on studios.studioid = StudioMovie.studioid WHERE StudioMovie.movieid = {id}
            List<Movie> Movies = await _context.Movies
                .Where(m => m.MovieID == id)
                .ToListAsync();

            // empty list of data transfer object StudioDto
            List<StudioDto> StudioDtos = new List<StudioDto>();

            List<Studio> Studios = await _context.Studios
                 .Where(s => s.StudioID == Movies[0].StudioID)
                 .ToListAsync();

                // foreach Studio Item record in database
                foreach (Studio Studio in Studios)
                  {
                    // create new instance of StudioDto
                    StudioDtos.Add(new StudioDto()
                    {
                        StudioID = Studio.StudioID,
                        StudioName = Studio.StudioName,
                        StudioCountry = Studio.StudioCountry,
                        StudioEstablishedYear = Studio.StudioEstablishedYear,
                        StudioCEO = Studio.StudioCEO,
                        StudioHeadquarter = Studio.StudioHeadquarter
                    });
                  }

            // return StudioDtos
            return StudioDtos;

        }

    }
}
