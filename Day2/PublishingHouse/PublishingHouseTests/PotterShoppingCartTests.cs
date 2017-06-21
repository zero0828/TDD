using System;
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

            target.addBookToCart(new List<Book>()
                                    {new Book() { Name = "第一集", Price = 100 }});

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
            target.addBookToCart(new List<Book>()
                                    {new Book() { Name = "第一集", Price = 100 }
                                    ,new Book() { Name = "第二集", Price = 100 }});

            //預期折扣後總金額
            var expected = 190m;

            //act
            var actual = target.CheckOut();

            //assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
