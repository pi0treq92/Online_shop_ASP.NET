using twoja_manufaktura.DAL;
using twoja_manufaktura.Models;
using twoja_manufaktura.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using twoja_manufaktura.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using twoja_manufaktura.Controllers;
using System.Data.Entity;

namespace twoja_manufaktura.Tests
{
    [TestClass]
    public class UnitTestHomeController
    {
       
        [TestMethod]
        public void StaticContentAction_WithViewNamePassed_ReturnsViewWithTheSameName()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.StaticContent("TestView") as ViewResult;

            // Assert
            Assert.AreEqual("TestView", result.ViewName);
        }
    }
}
