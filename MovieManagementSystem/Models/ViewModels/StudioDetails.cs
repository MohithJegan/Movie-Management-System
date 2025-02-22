namespace MovieManagementSystem.Models.ViewModels
{
    public class StudioDetails
    {
        //A category page must have a category
        public required StudioDto Studio { get; set; }

        public IEnumerable<MovieDto>? Movies { get; set; }
    }
}
