using System.ComponentModel.DataAnnotations.Schema;


namespace _60331_1_Volodko.DAL
{
    [Table("Manufacturers")]
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }

        public string ManufacturerName { get; set; }

    }
}
