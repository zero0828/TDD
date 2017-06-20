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
        /// 結帳
        /// </summary>
        /// <returns>總金額</returns>
        public decimal CheckOut()
        {
            return 100;
        }
        /// <summary>
        /// 加入書本到購物車
        /// </summary>
        public void addBookToCart()
        {
            
        }
    }
}
