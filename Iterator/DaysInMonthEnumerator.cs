using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class DaysInMonthEnumerator : IEnumerator<MonthWithDays>
    {
        private int year = 2024;
        private int month = 0;
        public MonthWithDays Current => new MonthWithDays()
        {
            Month =$"{year.ToString().PadLeft(4,'0')}-{month}",
            Days=DateTime.DaysInMonth(year, month),
        };

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Incase we want to clean up resources the enumerator needs , let's make it empty for now
        }

        public bool MoveNext()
        {
            month += 1;

            if(month >12) {
                month = 1;
                year +=1;
            }

            return year < 2030;
        }

        public void Reset()
        {
            month=0;
            year = 2024;
        }
    }
}
