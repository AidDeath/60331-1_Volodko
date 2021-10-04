using System.ComponentModel.DataAnnotations.Schema;

namespace _60331_1_Volodko.DAL
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
