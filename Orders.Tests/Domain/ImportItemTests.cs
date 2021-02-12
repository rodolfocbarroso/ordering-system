using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Domain.Entities;
using Orders.Domain.Enums;

namespace Orders.Tests.Domain
{
    [TestClass]
    public class ImportItemTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_valido_ele_deve_ser_criado()
        {
            var item = new ImportItem(1, "produto 1", DateTime.Now.AddDays(2), 2, 20);
            Assert.AreEqual(item.Valid, true);
        }
    }
}
