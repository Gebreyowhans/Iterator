using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class DaysInMonthEnumerator : IEnumerator<MonthWithDays>
    {
        private int year = 1;
        private int month = 0;

        public MonthWithDays Current => new MonthWithDays()
        {
            Date = $"{year.ToString().PadLeft(4, '0')}-{month}",
            Days = DateTime.DaysInMonth(year, month)
        };

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            return year < 5;
        }

        public void Reset()
        {
            month = 0;
            year = 1;
        }

    }
}
