using Microsoft.AspNetCore.Mvc;
using Moq;
using MyFirstSite.Controllers;
using MyFirstSite.Models;
using MyFirstSite.Models.Interfaces;
using MyFirstSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MyFirstSite.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            var mock = new Mock<IAllProducts>();
            mock.Setup(repo => repo.Products).Returns(GetTestProducts());
            var controller = new ProductsController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); //Является ли возвращаемый результат объектом ViewResult
            var model = Assert.IsAssignableFrom<ProductsViewModel>(viewResult.Model); //Передается ли в представление в качестве модели объект ProductsViewModel
            Assert.Equal(model.products.Count(), GetTestProducts().Count); //Проверяется количество объектов, которые передаются в представление
        }

        [Fact]
        public void Index1Test()
        {
            // Arrange
            var mock = new Mock<IAllProducts>();
            mock.Setup(repo => repo.getFavProducts).Returns(GetTestProducts());
            var controller = new ProductsController(mock.Object);

            // Act
            var result = controller.Index1();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); //Является ли возвращаемый результат объектом ViewResult
            var model = Assert.IsAssignableFrom<ProductsViewModel>(viewResult.Model); //Передается ли в представление в качестве модели объект ProductsViewModel
            Assert.Equal(model.products.Count(), GetTestProducts().Count); //Проверяется количество объектов, которые передаются в представление
        }



        public static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Маски", Desc = "100% защита"},
                        new Category {CategoryName = "Антисептики", Desc = "100% чистота"},
                        new Category {CategoryName = "Другое", Desc = "Интересное))"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }

        private List<Product> GetTestProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Маска", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 500, IsFavourite = true, Available = true, Category = Categories["Маски"] },
                new Product { Name = "Антисептик", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 150, IsFavourite = false, Available = true, Category = Categories["Антисептики"] },
                new Product { Name = "Костюм", ShortDesc = "", LongDesc = "", Img = "/img/Maska.jpg", Price = 50000, IsFavourite = true, Available = true, Category = Categories["Другое"] }

            };
            return products;
        }
    }
}
