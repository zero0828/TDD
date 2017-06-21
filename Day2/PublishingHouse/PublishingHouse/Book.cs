using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublishingHouse
{
    public enum SeriesOfBooks
    {
        one = 1,
        two,
        three,
        four,
        fives,
    }
    public class Book
    {
        public SeriesOfBooks series = SeriesOfBooks.one;
        public string name = string.Empty;
        public decimal price = decimal.Zero;
    }
}
