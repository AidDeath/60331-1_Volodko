using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace _60331_1_Volodko.DAL
{
    [Table("Sweets")]
    public class Sweet
    {
        [HiddenInput]
        public int SweetId { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Введите категорию")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } 

        [Required(ErrorMessage = "Введите изготовителя")]
        [Display(Name = "Изготовитель")]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Required(ErrorMessage = "Введите название изделия")]
        [Display(Name = "Название")]
        public string SweetsName { get; set; } 

        [Required(ErrorMessage = "Введите описание сладости")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Калорийность")]
        [Range(minimum: 500, maximum: 5000)]
        public int CalorieContent { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(minimum: 0, maximum: 500000)]
        public decimal Cost { get; set; } 

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; } 
        public string MimeType { get; set; } 
    }
}
