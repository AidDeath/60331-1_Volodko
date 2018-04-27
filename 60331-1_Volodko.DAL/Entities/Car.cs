using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _60331_1_Volodko.DAL
{
    public class Car
    {
        [HiddenInput]
        public int CarId { get; set; } // id авто
        [Required(ErrorMessage = "Введите бренд автомобиля")]
        [Display(Name = "Бренд")]
        public string CarBrand { get; set; } // бренд авто (в роли категории)
        [Required(ErrorMessage = "Введите модель автомобиля")]
        [Display(Name = "Модель")]
        public string CarModel { get; set; } // модель авто
        [Required(ErrorMessage = "Введите описание автомобиля")]
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание авто (модели авто)
        [Required]
        [Display(Name = "Объем двигателя")]
        [Range(minimum: 500, maximum: 5000)]
        public int EngineCapacity { get; set; } // объем двигателя
        [Required]
        [Display(Name = "Цена")]
        [Range(minimum: 0, maximum: 500000)]
        public decimal Cost { get; set; } // цена авто
        [Display(Name = "Изображение")]
        public byte[] Image { get; set; } // данные изображения
        public string MimeType { get; set; } // Mime - тип данных изображения 
    }
}
