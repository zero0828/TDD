using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationFromCollection
{
    /// <summary>
    /// 依照特定條件，計算集合中的資料
    /// </summary>
    public class CalculationByGroupFromCollection
    {
        /// <summary>
        /// 依照特定條件，計算集合中的資料
        /// </summary>
        public CalculationByGroupFromCollection()
        {
        }
        /// <summary>
        /// 檢查集合
        /// <para>當空集合則拋出例外ArgumentException</para>
        /// </summary>
        /// <param name="Collection"></param>
        private void IsCollectionTheNullThrowArgumentException<TSource>(IEnumerable<TSource> Collection)
        {
            if (!Collection.Any()) { throw new ArgumentException("加總的數量小於1"); }
        }

        /// <summary>
        /// 依照從集合中依照順序，進行分組後進行指定項目加總
        /// </summary>
        /// <param name="GroupSize">數量進行分組</param>
        /// <param name="selector">欄位</param>
        /// <returns>加總後的數值</returns>
        public IEnumerable<int> Sum<TSource>(IEnumerable<TSource> Collection, int GroupSize, Func<TSource, int> selector)
        {
            IsCollectionTheNullThrowArgumentException(Collection);
            if (GroupSize <= 0) { throw new ArgumentException("加總的數量小於1"); }

            List<int> Sums = new List<int>();

            foreach (IEnumerable<TSource> subCollection in GroupBySize(Collection, GroupSize))
            {
                Sums.Add(subCollection.Sum(selector));
            } 
            return Sums;
        }
        /// <summary>
        /// 對集合依照順序進行分組
        /// </summary>
        /// <param name="Size">一組數量</param>
        /// <returns>一個集合中包含多個子集</returns>
        private IEnumerable<IEnumerable<TSource>> GroupBySize<TSource>(IEnumerable<TSource> Collection, int Size)
        {
            List<List<TSource>> Collections = new List<List<TSource>>();
            int SubCollectionCount = Collection.Count() / Size;
            if ((Collection.Count() / Size) != 0) { SubCollectionCount++; }
            for (int count = 0; count < SubCollectionCount; count++)
            {
                Collections.Add(new List<TSource>());
            }
            List<TSource> Items = Collection.ToList();
            for (int count = 0; count < Collection.Count(); count++)
            {
                int Index = count / Size;
                Collections[Index].Add(Items[count]);
            }
            return Collections;
        }
    }
}
