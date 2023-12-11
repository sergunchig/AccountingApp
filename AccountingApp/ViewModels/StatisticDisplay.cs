using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.ViewModels
{
    public class StatisticDisplay
    {
        public string Month { get; set; }
        public string Cathegory { get; set; }
        public float Total { get; set; }

        public static readonly string[] fields = new string[] { null, "Категория затрат", "Всего затрат" };
    }
    public class StatisticComparer : IEqualityComparer<StatisticDisplay>
    {
        public bool Equals(StatisticDisplay? x, StatisticDisplay? y)
        {
            return x.Month.Equals(y.Month) && x.Cathegory.Equals(y.Cathegory);
        }

        public int GetHashCode([DisallowNull] StatisticDisplay obj)
        {
            return obj.Month.GetHashCode()+obj.Cathegory.GetHashCode();
        }
    }
}
