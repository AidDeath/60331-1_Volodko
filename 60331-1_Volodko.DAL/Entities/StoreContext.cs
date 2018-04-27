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
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    NickName = "SuperHero" };

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
        }
    }
}
