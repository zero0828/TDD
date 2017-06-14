using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationByGroupFromCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using ExpectedObjects;

namespace CalculationByGroupFromCollection.Tests
{
    [TestClass()]
    public class CalculationByGroupFromCollectionTests
    {
        /// <summary>
        /// 測試用的來源數據
        /// </summary>
        /// <returns>Input</returns>
        private IEnumerable<Product> StubProducts()
        {
            IList<Product> Products = new List<Product>();

            Products.Add(new Product() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            Products.Add(new Product() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            Products.Add(new Product() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            Products.Add(new Product() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            Products.Add(new Product() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            Products.Add(new Product() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            Products.Add(new Product() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            Products.Add(new Product() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            Products.Add(new Product() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            Products.Add(new Product() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            Products.Add(new Product() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });

            return Products;
        }

        [TestMethod()]
        public void SumTest_由StubProducts中3筆一組_取Cost總和分別為_6_15_24_21()
        {
            //arrange
            var products = StubProducts();
            var target = new CalculationByGroupFromCollection<Product>(products);

            var expected = new List<int> { 6, 15, 24, 21 };
            int GroupSize = 3;
            //act
            var actual = target.Sum(GroupSize, (p) => p.Cost);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void SumTest_由StubProducts中4筆一組_取Revenue總和分別為_50_66_60()
        {
            //arrange
            var products = StubProducts();
            var target = new CalculationByGroupFromCollection<Product>(products);


            var expected = new List<int> { 50, 66, 60 };
            int GroupSize = 4;
            //act
            var actual = target.Sum(GroupSize, (p) => p.Revenue);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void SumTest_輸入GroupSize為0_預期會拋ArgumentException()
        {
            //arrange
            var products = StubProducts();
            var target = new CalculationByGroupFromCollection<Product>(products);
            var expected = new int[] { 50, 66, 60 };

            int GroupSize = 0;
            //act
            Action actual = () => target.Sum(GroupSize, (p) => p.Revenue);

            //assert 
            actual.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void SumTest_輸入GroupSize為負數_預期會拋ArgumentException()
        { 
            //arrange
            var products = StubProducts();
            var target = new CalculationByGroupFromCollection<Product>(products);
            var expected = new int[] { 50, 66, 60 };

            int GroupSize = -1;
            //act
            Action actual = () => target.Sum(GroupSize, (p) => p.Revenue);

            //assert 
            actual.ShouldThrow<ArgumentException>();
        }
        
        //讓編譯器處理
        //[TestMethod()]
        //public void SumTest_當集合中加總的欄位不存在_預期會拋ArgumentException()
        //{
        //    //arrange
        //    var products = StubProducts();
        //    var target = new CalculationByGroupFromCollection<Product>(products);


        //    var expected = new int[] { 50, 66, 60 };
        //    int GroupSize = 4;

        //    //act
        //    Action actual = () => target.Sum(GroupSize, (p) => p.Id);

        //    //assert 
        //    actual.ShouldThrow<ArgumentException>();
        //}
        
        /// <summary>
        /// 測試時使用的假型別
        /// </summary>
        private class Product
        {
            public int Id;
            public int Cost;
            public int Revenue;
            public int SellPrice;
        }
    }

}
