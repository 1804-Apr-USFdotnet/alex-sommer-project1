using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurauntWebApp.Controllers;
using RestaurauntLibrary;

namespace RestaurauntWebApp.Tests.Controllers
{
    [TestClass]
    public class RestaurauntControllerTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            RestaurauntController cont = new RestaurauntController();
            string expected = "GetAll";
            var action = cont.GetAll() as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCreate()
        {
            RestaurauntController cont = new RestaurauntController();
            string expected = "Create";
            var action = cont.Create() as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        public void TestDelete()
        {
            RestaurauntController cont = new RestaurauntController();
            string expected = "Create";
            var action = cont.Create() as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        public void TestDetails()
        {
            RestaurauntController cont = new RestaurauntController();
            string expected = "Create";
            var action = cont.Create() as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
    }
}
