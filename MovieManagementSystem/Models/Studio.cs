using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.Models
{
    public class Studio
    {
        [Key]
        public int StudioID { get; set; }
        public string StudioName { get; set; }
        public string StudioCountry {  get; set; }
        public int StudioEstablishedYear {  get; set; }
        public string StudioCEO { get; set; }
        public string StudioHeadquarter {  get; set; }

    }

    public class StudioDto
    {
        public int StudioID { get; set; }
        public string StudioName { get; set; }
        public string StudioCountry { get; set; }
        public int StudioEstablishedYear { get; set; }
        public string StudioCEO { get; set; }
        public string StudioHeadquarter { get; set; }
    }
}
