using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Domain.Entities;
using Orders.Domain.Enums;

namespace Orders.Tests.Domain
{
    [TestClass]
    public class SpreadsheetItemTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_a_linha_invalida_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_o_nome_maior_que_50_caracteres_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }
    }
}
