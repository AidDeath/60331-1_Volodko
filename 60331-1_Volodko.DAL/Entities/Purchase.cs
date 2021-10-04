using System.ComponentModel.DataAnnotations.Schema;
using _60331_1_Volodko.DAL;
using Microsoft.AspNet.Identity.EntityFramework;


namespace _60331_1_Volodko.DAL
{
    [Table("Purchases")]
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [ForeignKey("Sweet")]
        public int SweetId { get; set; }

        public Sweet Sweet { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
