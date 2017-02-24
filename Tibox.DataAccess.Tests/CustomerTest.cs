using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.UnitOfWork;
using System.Linq;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerTest
    {
        private readonly TiboxUnitOfWork _unit;
        public CustomerTest()
        {
            _unit = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customer()
        {
            var customerList = _unit.Customers.GetAll();
            Assert.AreEqual(customerList.Count() > 0, true);
        }
    }
}
