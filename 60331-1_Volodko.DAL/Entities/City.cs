using System.ComponentModel.DataAnnotations.Schema;

namespace _60331_1_Volodko.DAL
{
    [Table("Cities")]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
