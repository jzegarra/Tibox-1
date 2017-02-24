using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.UnitOfWork;
using System.Linq;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderTest
    {
        private readonly TiboxUnitOfWork _unit;
        public OrderTest()
        {
            _unit = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Orders()
        {
            var orderList = _unit.Orders.GetAll();
            Assert.AreEqual(orderList.Count() > 0, true);
        }
    }
}
