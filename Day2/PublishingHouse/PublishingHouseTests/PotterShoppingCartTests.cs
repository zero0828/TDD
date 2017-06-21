﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishingHouse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PublishingHouse.Tests
{
    /// <summary>
    /// Feature: PotterShoppingCart
    /// In order to 提供最便宜的價格給來買書的爸爸媽媽
    /// As a 佛心的出版社老闆
    /// I want to 設計一個哈利波特的購物車
    /// </summary>
    [TestClass()]
    public class PotterShoppingCartTests
    {
        [TestMethod()]
        public void CheckOutTest_只買第一集_數量為1本_單價100元_結帳總金額為100元()
        {
            //arrange 
            var target = new PotterShoppingCart();

            target.addMerchandiseToCart<Book>(new List<Book>() {
                                        new Book() { Name = "第一集", Price = 100 } },
                                        (book) => book.Price);

            //每一本都是賣100元
            var expected = 100m;

            //act
            var actual = target.CheckOut();

            //assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckOutTest_第一集與第二集各買1本_1本單價100元_打95折_結帳總金額為190元()
        {
            //arrange 
            var target = new PotterShoppingCart();

            //每一本單價100元   
            target.addMerchandiseToCart<Book>(new List<Book>() {
                                    new Book() { Name = "第一集", Price = 100 },
                                    new Book() { Name = "第二集", Price = 100 }},
                                    (book) => book.Price);

            //預期折扣後總金額
            var expected = 190m;

            //act
            var actual = target.CheckOut();

            //assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckOutTest_第一到三集各買1本_共三本書_1本單價100元_打9折_結帳總金額為270元()
        {
            //arrange 
            var target = new PotterShoppingCart();

            //每一本單價100元   
            target.addMerchandiseToCart<Book>(new List<Book>(){
                                    new Book() { Name = "第一集", Price = 100 },
                                    new Book() { Name = "第二集", Price = 100 },
                                    new Book() { Name = "第三集", Price = 100 }},
                                    (book) => book.Price);

            //預期折扣後總金額
            var expected = 270m;

            //act
            var actual = target.CheckOut();

            //assert 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckOutTest_第一到四集各買1本_共四本書_1本單價100元_打8折_結帳總金額為320元()
        {
            //arrange 
            var target = new PotterShoppingCart();

            //每一本單價100元   
            target.addMerchandiseToCart<Book>(new List<Book>(){
                                    new Book() { Name = "第一集", Price = 100 },
                                    new Book() { Name = "第二集", Price = 100 },
                                    new Book() { Name = "第三集", Price = 100 },
                                    new Book() { Name = "第四集", Price = 100 }},
                                    (book) => book.Price);

            //預期折扣後總金額
            var expected = 320m;

            //act
            var actual = target.CheckOut();

            //assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
