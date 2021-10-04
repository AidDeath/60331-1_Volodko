using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace _60331_1_Volodko.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Sweet>().Property(s=> s.Cost).HasPrecision(18, 2);
            base.OnModelCreating(builder);
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Sweet> Sweets { get; set; }

        public void Populate()
        {
            if (!Roles.Any())
            {
                // Создаем менеджеры ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

                // Создаем роли "admin" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));

                // Создаем пользователя
                var userAdmin = new ApplicationUser {
                    Email = "admin@wssids.by",
                    UserName = "admin@wssids.by",
                    NickName = "WssIDs" };

                userManager.CreateAsync(userAdmin, "123456").Wait();

                // Добавляем созданного пользователя в администраторы 
                userManager.AddToRole(userAdmin.Id, "admin"); 
            }

            if (!Cars.Any())
            {
                List<Car> cars = new List<Car>
                {
                    new Car {CarId=1,CarBrand="BMW",CarModel="M3",Description="Высокотехнологичная спортивная версия компактных автомобилей BMW 3 серии",EngineCapacity=3000,Cost=88095},
                    new Car {CarId=2,CarBrand="BMW",CarModel="I8",Description="BMW Vision Efficient Dynamics представляет собой полноприводное двухдверное купе",EngineCapacity=2000,Cost=30000},
                    new Car {CarId=3,CarBrand="BMW",CarModel="X1",Description="Компактный кроссовер. Производство автомобиля началось на заводе в Лейпциге",EngineCapacity=2000,Cost=28000},
                    new Car {CarId=4,CarBrand="BMW",CarModel="X2",Description="Экспрессивная форма вместе с динамичным силуэтом придает ему подчеркнуто спортивный характер купе BMW",EngineCapacity=2000,Cost=28000},
                    new Car {CarId=5,CarBrand="BMW",CarModel="X3",Description="люксовый компактный кроссовер немецкой компании BMW. X3 первого поколения разработан и выпускался совместно с компанией Magna Steyr на заводе в Граце, Австрия",EngineCapacity=2000,Cost=28000},
                    new Car {CarId=6,CarBrand="Audi",CarModel="A1",Description="Cубкомпактный автомобиль Audi, представленный широкой общественности 4 марта 2010 года на Женевском автосалоне",EngineCapacity=2000,Cost=4324},
                    new Car {CarId=7,CarBrand="Audi",CarModel="A2",Description="Cубкомпактвэн с алюминиевым кузовом немецкой автомобилестроительной компании Audi AG (в составе концерна Volkswagen AG)",EngineCapacity=2000,Cost=432432},
                    new Car {CarId=8,CarBrand="Audi",CarModel="A3",Description="Хэтчбэк малого семейного класса, производимый концерном Audi с 1996 года. В 1996—2003 годах выпускалось первое поколение, с 2003 по 2012 — второе, а в 2012 появилось 3 поколение популярного в Европе компактного автомобиля",EngineCapacity=2000,Cost=432432},
                    new Car {CarId=9,CarBrand="Audi",CarModel="A4",Description="Представляет собой семейство моделей среднего класса, выпускаемых под маркой Audi",EngineCapacity=2000,Cost=54353},
                    new Car {CarId=10,CarBrand="Audi",CarModel="R8",Description="Cреднемоторный полноприводный спортивный автомобиль, производимый немецким автопроизводителем Audi с 2007 года",EngineCapacity=2000,Cost=32143},
                    new Car {CarId=11,CarBrand="Bugatti",CarModel="Veyron",Description="Гиперкар компании Bugatti, производившийся с 2005 по 2015 год",EngineCapacity=2000,Cost=45434},
                    new Car {CarId=12,CarBrand="Bugatti",CarModel="Chiron",Description="Гиперкар компании Bugatti (входит в концерн Volkswagen), официально представлен публике в 2016 году",EngineCapacity=2000,Cost=432432},
                    new Car {CarId=13,CarBrand="Chevrolet",CarModel="Aveo",Description="Cубкомпактный автомобиль, производящийся General Motors с 2002 год",EngineCapacity=2000,Cost=32143},
                    new Car {CarId=14,CarBrand="Chevrolet",CarModel="Camaro",Description="Культовый американский спортивный автомобиль, pony car, выпускаюшийся подразделением Chevrolet корпорации General Motors с 1966 года",EngineCapacity=2000,Cost=45434},
                    new Car {CarId=15,CarBrand="Chevrolet",CarModel="Corvette",Description="Двухместный заднеприводный спортивный автомобиль, выпускаемый под маркой Chevrolet компанией General Motors в США с 1953 года",EngineCapacity=2000,Cost=432432},
                    new Car {CarId=16,CarBrand="Lamborghini",CarModel="Aventador",Description=" спортивный автомобиль, выпускающийся компанией Lamborghini",EngineCapacity=2000,Cost=32143},
                    new Car {CarId=17,CarBrand="Lamborghini",CarModel="Murciélago",Description="суперкар, выпускавшийся компанией Lamborghini в Сант'Агата-Болоньезе",EngineCapacity=2000,Cost=45434},
                    new Car {CarId=18,CarBrand="Lamborghini",CarModel="Gallardo",Description="Cпорткар, выпускавшийся компанией Lamborghini c 2003 по 2013 года",EngineCapacity=2000,Cost=432432},
                    new Car {CarId=19,CarBrand="Lamborghini",CarModel="Huracan",Description="Cпортивный автомобиль производства итальянской компании Lamborghini, который заменил Lamborghini Gallardo",EngineCapacity=2000,Cost=32143},
                    new Car {CarId=20,CarBrand="Lamborghini",CarModel="Veneno",Description="Итальянский суперкар, выпущенный ограниченной серией в 2013 году компанией Lamborghini. ",EngineCapacity=2000,Cost=45434},
                    new Car {CarId=21,CarBrand="Porsche",CarModel="911",Description="Cпортивный автомобиль производства немецкой компании Porsche AG в кузове двухдверное купе или кабриолет на его основе, в разных поколениях производящегося с 1964 года по наши дни",EngineCapacity=2000,Cost=432432},
                }; 
                Cars.AddRange(cars);
                SaveChanges();
            }

            if (!Cities.Any())
            {
                List<City> cities = new List<City>
                {
                    new City {CityId = 1, CityName = "Ивенец"},
                    new City {CityId = 2, CityName = "Минск"},
                    new City {CityId = 3, CityName = "Гомель"},
                    new City {CityId = 4, CityName = "Клецк"},
                    new City {CityId = 5, CityName = "Симферополь"},
                };
                Cities.AddRange(cities);
                SaveChanges();
            }

            if (!Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category {CategoryId = 1, CategoryName = "Конфеты"},
                    new Category {CategoryId = 2, CategoryName = "Пирожные"},
                    new Category {CategoryId = 3, CategoryName = "Батончики"},
                    new Category {CategoryId = 4, CategoryName = "Торты"},
                };
                Categories.AddRange(categories);
                SaveChanges();
            }

            if (!Manufacturers.Any())
            {
                var manufacturers = new List<Manufacturer>
                {
                    new Manufacturer {ManufacturerId = 1, CityId = 1, ManufacturerName = "ОАО ИВКОН"},
                    new Manufacturer {ManufacturerId = 2, CityId = 3, ManufacturerName = "Гомельские конфеты"},
                    new Manufacturer {ManufacturerId = 3, CityId = 3, ManufacturerName = "Коммунарка"},
                    new Manufacturer {ManufacturerId = 4, CityId = 3, ManufacturerName = "Спартак"},
                    new Manufacturer {ManufacturerId = 5, CityId = 4, ManufacturerName = "ОДО Лучшие традиции"},
                    new Manufacturer {ManufacturerId = 6, CityId = 5, ManufacturerName = "Roshen"}
                };
                Manufacturers.AddRange(manufacturers);
                SaveChanges();
            }

            if (!Sweets.Any())
            {
                var sweets = new List<Sweet>
                {
                    new Sweet{SweetId = 1, CategoryId = 1, ManufacturerId = 3, CalorieContent = 323, SweetsName = "Вечерочек", Cost = 1000, Description = "Вкуснейшие конфеты, знакомые с детства"},
                    new Sweet{SweetId = 2, CategoryId = 1, ManufacturerId = 3, CalorieContent = 323, SweetsName = "Красные зори", Cost = 500, Description = "Немного приторные, но всё ещё вкусные"},
                    new Sweet{SweetId = 3, CategoryId = 1, ManufacturerId = 1, CalorieContent = 123, SweetsName = "Дюшес", Cost = 500, Description = "Леденцы с ароматом дюшеса"},
                    new Sweet{SweetId = 4, CategoryId = 1, ManufacturerId = 1, CalorieContent = 54, SweetsName = "Барбарис", Cost = 451, Description = "Леденцы с ароматом Барбариса"},
                    new Sweet{SweetId = 5, CategoryId = 1, ManufacturerId = 5, CalorieContent = 324, SweetsName = "Столичные", Cost = 4351, Description = "Все думают, что эти конфеты с водкой"},
                    new Sweet{SweetId = 6, CategoryId = 1, ManufacturerId = 5, CalorieContent = 314, SweetsName = "Беловежская пуща", Cost = 51, Description = "Вот эти конфеты точно с водкой"},
                    new Sweet{SweetId = 7, CategoryId = 2, ManufacturerId = 3, CalorieContent = 923, SweetsName = "Ленинградское", Cost = 321, Description = "Песочные коржи пропитанные масляным кремом"},
                    new Sweet{SweetId = 8, CategoryId = 2, ManufacturerId = 3, CalorieContent = 1043, SweetsName = "Ласточка", Cost = 4341, Description = "Нежное суфле на биквитной подушке"},
                    new Sweet{SweetId = 9, CategoryId = 2, ManufacturerId = 3, CalorieContent = 4133, SweetsName = "Полночь", Cost = 111, Description = "слоёное тесто, незабываемый вкус"},
                    new Sweet{SweetId = 10, CategoryId = 3, ManufacturerId = 5, CalorieContent = 343, SweetsName = "Сникерс", Cost = 1234, Description = "Тот свмый шоколадный батончик"},
                    new Sweet{SweetId = 11, CategoryId = 3, ManufacturerId = 5, CalorieContent = 4777, SweetsName = "Твикс", Cost = 43213, Description = "Когда нет сникерса"},
                };
                Sweets.AddRange(sweets);
                SaveChanges();
            }
        }
    }
}
