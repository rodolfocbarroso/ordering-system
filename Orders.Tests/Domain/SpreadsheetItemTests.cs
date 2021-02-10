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
        public void Dado_um_item_com_a_linha_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            var item = new SpreadsheetItem(0, "produto 1", DateTime.Now.AddDays(2), 2, 2000);
            Assert.AreNotEqual(0, item.Line);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_o_nome_vazio_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_o_nome_maior_que_50_caracteres_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_data_de_entrega_vazia_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_data_de_entrega_menor_ou_igual_ao_dia_de_hoje_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_quantidade_menor_ou_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_um_preco_unitario_menor_ou_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            Assert.Fail();
        }
    }
}
