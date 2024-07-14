using System.ComponentModel.DataAnnotations;

namespace HotelListing.Data
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
