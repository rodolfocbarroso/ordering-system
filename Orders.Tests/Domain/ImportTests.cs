﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orders.Domain.Entities;
using Orders.Domain.Enums;

namespace Orders.Tests.Domain
{
    [TestClass]
    public class ImportTests
    {
        private readonly Import _import = new Import(FileExtension.Xlsx);

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_a_linha_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(0, "produto 1", DateTime.Now.AddDays(2), 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_o_nome_vazio_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "", DateTime.Now.AddDays(2), 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_o_nome_maior_que_50_caracteres_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "o nome de um item da planilha com mais de 50 caracteres", DateTime.Now.AddDays(2), 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_data_de_entrega_vazia_o_mesmo_nao_pode_ser_adicionado()
        {
            var deliveryDate = new DateTime(0001, 01, 01);

            _import.AddItem(1, "produto 1", deliveryDate, 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_data_de_entrega_menor_que_o_dia_de_hoje_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(-1), 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_data_de_entrega_igual_ao_dia_de_hoje_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Today, 2, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_quantidade_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(2), 0, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_uma_quantidade_menor_que_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(2), -1, 2000);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_um_preco_unitario_igual_a_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(2), 2, 0);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_item_com_um_preco_unitario_menor_que_zero_o_mesmo_nao_pode_ser_adicionado()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(2), 2, -1);
            Assert.AreEqual(_import.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_arquivo_ele_deve_gerar_uma_importacao()
        {
            _import.AddItem(1, "produto 1", DateTime.Now.AddDays(2), 2, 20);
            Assert.AreEqual(_import.Valid, true);
        }
    }
}
