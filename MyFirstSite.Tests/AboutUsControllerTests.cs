using Microsoft.AspNetCore.Mvc;
using MyFirstSite.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyFirstSite.Tests
{
    public class AboutUsControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            AboutUsController controller = new AboutUsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("", result?.ViewData["Message"]); //проверяет значение по ключу "Message" в словаре ViewData
            Assert.NotNull(result); //Тестируем результат метода - возвращаемый объект ViewResult не должен иметь значение null
            Assert.Equal("Index", result?.ViewName); //Проверяет название вызываемого представления
        }
    }
}
