using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyFirstSite.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result); //Тестируем результат метода - возвращаемый объект ViewResult не должен иметь значение null
            Assert.Equal("Index", result?.ViewName); //Проверяет название вызываемого представления
        }


    }
}
