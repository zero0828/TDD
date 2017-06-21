using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublishingHouse
{
    /// <summary>
    /// 哈利波特購物車
    /// </summary>
    /// <remarks>
    /// <para>定價的方式如下：</para>
    /// <para>1. 一到五集的哈利波特，每一本都是賣100元</para>
    /// <para>2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣</para>
    /// <para>3. 如果你買了三本不同的書，則會有10%的折扣</para>
    /// <para>4. 如果是四本不同的書，則會有20%的折扣</para>
    /// <para>5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣</para>
    /// <para>6. 需要留意的是，如果你買了四本書，其中三本不同，第四本則是重複的，</para>
    /// <para>   那麼那三本將享有10%的折扣，但重複的那一本，則仍須100元。</para>
    /// </remarks>
    public class PotterShoppingCart
    {
        /// <summary>
        /// 所有商品
        /// </summary>
        private List<Book> merchandises = new List<Book>();

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns>總金額</returns>
        public decimal CheckOut()
        {
            return CalculateTotalPrice();
        }
        /// <summary>
        /// 計算總價格
        /// </summary>
        /// <returns></returns>
        private decimal CalculateTotalPrice()
        {
            var originalPrice = this.merchandises.Sum(book => book.price);
            var discountMoney = this.CalculateTheDiscountMoney();
            var totalPrice = originalPrice - discountMoney;
            return totalPrice;
        }
        /// <summary>
        /// 加入書本到購物車
        /// </summary>           
        public void addMerchandiseToCart(IEnumerable<Book> books)
        {
            this.merchandises.AddRange(books);
        }
        /// <summary>
        /// 計算總共折扣多少錢
        /// </summary>
        private decimal CalculateTheDiscountMoney()
        {
            decimal discountMoney = decimal.Zero;
           
            var notYetDiscountBooks = this.merchandises.ToList();            
            var discountNumber = this.merchandises.GroupBy(book => book.series).Max(group => group.Count());
           
            for (; discountNumber > 0; discountNumber--)
            {
                var discountBooks = notYetDiscountBooks.GroupBy(book => book.series).Select(g => g.First()).ToList();
                var discount = this.CalculateTheDiscount(discountBooks.Count());
                var originalPrice = discountBooks.Sum(book => book.price);
                discountMoney += originalPrice * (1 - discount);
                foreach (var book in discountBooks)
                {
                    notYetDiscountBooks.Remove(book);
                }
            }

            return discountMoney;
        }
        /// <summary>
        /// 計算折扣
        /// </summary>
        /// <param name="bookCount"></param>
        /// <returns></returns>
        private decimal CalculateTheDiscount(int bookCount)
        {
            switch (bookCount)
            {
                case 2:
                    return 0.95m;
                case 3:
                    return 0.9m;
                case 4:
                    return 0.8m;
                case 5:
                    return 0.75m;
                default:
                    return 1m;
            }
        }
    }
}
