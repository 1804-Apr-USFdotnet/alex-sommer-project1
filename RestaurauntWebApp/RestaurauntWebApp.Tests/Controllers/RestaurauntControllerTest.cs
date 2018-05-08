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
            var action = cont.GetAll(null) as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCreate()
        {
            RestaurauntController cont = new RestaurauntController();
            Restauraunt testeraunt = new Restauraunt()
            {
                Name = "Testeraunt",
                City = "Nowhere",
                State = "Utah",
                Address= "12345 Streetname"
            };
            string expected = "Create";
            var action = cont.Create(testeraunt) as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        public void TestDelete()
        {
            RestaurauntController cont = new RestaurauntController();
            Restauraunt testeraunt = new Restauraunt()
            {
                ID = 0,
                Name = "Testeraunt",
                City = "Nowhere",
                State = "Utah",
                Address = "12345 Streetname"
            };
            string expected = "Delete";
            var action = cont.Delete(0) as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
        public void TestDetails()
        {
            RestaurauntController cont = new RestaurauntController();
            Restauraunt testeraunt = new Restauraunt()
            {
                ID = 0,
                Name = "Testeraunt",
                City = "Nowhere",
                State = "Utah",
                Address = "12345 Streetname"
            };
            string expected = "Details";
            var action = cont.Details(0) as ViewResult;
            string actual = action.ViewName;
            Assert.AreEqual(expected, actual);
        }
    }
}
