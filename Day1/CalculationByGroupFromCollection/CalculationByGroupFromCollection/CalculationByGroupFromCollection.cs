using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationByGroupFromCollection
{
    /// <summary>
    /// 依照特定條件，計算集合中的資料
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CalculationByGroupFromCollection<T>
    {
        public IEnumerable<T> _Collection;
        /// <summary>
        /// 依照特定條件，計算集合中的資料
        /// </summary>
        /// <param name="Collection">資料集合</param>
        public CalculationByGroupFromCollection(IEnumerable<T> Collection)
        {
            if (!Collection.Any()) { throw new ArgumentException("加總的數量小於1"); }
            this._Collection = Collection;
        }
        /// <summary>
        /// 依照從集合中依照順序，進行分組後進行指定項目加總
        /// </summary>
        /// <param name="GroupSize">數量進行分組</param>
        /// <param name="selector">欄位</param>
        /// <returns>加總後的數值</returns>
        public IEnumerable<int> Sum(int GroupSize, Func<T, int> selector)
        {
            if (GroupSize <= 0) { throw new ArgumentException("加總的數量小於1"); }
            
            List<int> Sums = new List<int>();
            
            foreach (IEnumerable<T> subCollection in GroupBySize(GroupSize))
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
        private IEnumerable<IEnumerable<T>> GroupBySize(int Size)
        {
            List<List<T>> Collections = new List<List<T>>();
            int SubCollectionCount = this._Collection.Count() / Size;
            if ((this._Collection.Count() / Size) != 0) { SubCollectionCount++; }
            for (int count = 0; count < SubCollectionCount; count++)
            {
                Collections.Add(new List<T>());                 
            }
            List<T> Items = this._Collection.ToList();
            for (int count = 0; count < this._Collection.Count(); count++)
            {
                int Index = count / Size;
                Collections[Index].Add(Items[count]);
            }
            return Collections;
        }
    }
}
