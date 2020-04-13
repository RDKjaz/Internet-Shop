using Microsoft.AspNetCore.Mvc;
using Moq;
using MyFirstSite.Controllers;
using MyFirstSite.Models;
using MyFirstSite.Models.Interfaces;
using MyFirstSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyFirstSite.Tests
{
    public class CategoryControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            var mock = new Mock<IAllProducts>();
            var mock1 = new Mock<ICategories>();
            mock.Setup(repo => repo.Products).Returns(GetTestProducts());
            mock1.Setup(repo => repo.AllCategories).Returns(GetTestCategories());

            var controller = new CategoryController(mock.Object, mock1.Object);

            // Act
            string a = "";
            var result = controller.List(a);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); //Является ли возвращаемый результат объектом ViewResult
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.Model); //Передается ли в представление в качестве модели объект ProductsViewModel
            //Assert.Equal(model.products.Count(), GetTestProducts().Count); //Проверяется количество объектов, которые передаются в представление
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
        private List<Category> GetTestCategories()
        {
            var categories = new List<Category>
            {
                 new Category {CategoryName = "Маски", Desc = "100% защита"},
                 new Category {CategoryName = "Антисептики", Desc = "100% чистота"},
                 new Category {CategoryName = "Другое", Desc = "Интересное))"}
            };
            return categories;
        }
    }
}
