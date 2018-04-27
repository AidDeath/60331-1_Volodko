using System;
using _60331_1_Volodko.Controllers;
using _60331_1_Volodko.Models;
using _60331_1_Volodko.DAL;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace _60331_1_Volodko.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Car>>();
            mock.Setup(r => r.GetAll())
                .Returns(new List<Car>{
                    new Car { CarId=1 },
                    new Car { CarId=2 },
                    new Car { CarId=3 },
                    new Car { CarId=4 },
                    new Car { CarId=5 },
            });
            // Создание объекта контроллера
            var controller = new CarController(mock.Object);

            // Act
            // Вызов метода List
            // Макеты для получения HttpContext HttpRequest 
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера 

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object; 

            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Car> model = view.Model as PageListViewModel<Car>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].CarId);
            Assert.AreEqual(5, model[1].CarId);
        }

        [TestMethod]
        public void Category()
        {
            // Arrange
            // Макет репозитория 
            var mock = new Mock<IRepository<Car>>();
            mock.Setup(r => r.GetAll()) .Returns(new List<Car>
            {
                new Car { CarId=1, CarBrand="1" },
                new Car { CarId=2, CarBrand="2" },
                new Car { CarId=3, CarBrand="1" },
                new Car { CarId=4, CarBrand="2" },
                new Car { CarId=5, CarBrand="2" },
            });

            // Создание объекта контроллера
            var controller = new CarController(mock.Object);

            // Act
            // Вызов метода List
            // Макеты для получения HttpContext HttpRequest 
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера 

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            var view = controller.List("1", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Car> model = view.Model as PageListViewModel<Car>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].CarId);
            Assert.AreEqual(3, model[1].CarId);
        }
    }
}
