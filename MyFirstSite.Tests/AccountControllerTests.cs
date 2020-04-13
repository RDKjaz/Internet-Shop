using Microsoft.AspNetCore.Mvc;
using Moq;
using MyFirstSite.Controllers;
using MyFirstSite.Models;
using MyFirstSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace MyFirstSite.Tests
{
    public class AccountControllerTests
    {
        public DataBaseContext context;
        Regex email = new Regex(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})");

        [Fact]
        public void LoginTest()
        {
            // Arrange
            var mock = new Mock<IUsers>();
            LoginModel loginModel = new LoginModel();
            mock.Setup(repo => repo.getObjectUser(1)).Returns(GetTestUsers());
            var controller = new AccountController(context);

            // Act
            var result = controller.Login(loginModel);

            // Assert
            Assert.IsNotType<ViewResult>(result);
            Assert.Matches(email, GetTestUsers().Email);
        }


        public static Dictionary<string, Role> roles;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles == null)
                {
                    var list = new Role[]
                    {
                        new Role {Name = "admin",Desc=""},
                        new Role {Name = "user",Desc=""}
                    };
                    roles = new Dictionary<string, Role>();
                    foreach (Role el in list)
                        roles.Add(el.Name, el);
                }
                return roles;
            }
        }

        public User GetTestUsers()
        {
            User us = new User { Email = "Radik@gmail.com", Password = "7777", Role = Roles["admin"] };
            return us;
        }
    }
}
