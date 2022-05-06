using System;

namespace Payday
{
    public class Payday
    {
        private int _endOfFirstPayPeriod = 15;
        private DateTime _currentDay;

        public DateTime CurrentDay
        {
            get
            {
                return _currentDay;
            }
        }

        public int DaysToPayday
        {
            get
            {
                TimeSpan DaysUntilPayday = NextPayday() - CurrentDay;
                return DaysUntilPayday.Days;
            }
        }

        public int DaysToEndOfMonth
        {
            get
            {
                return GetLastDayOfMonth() - CurrentDay.Day;
            }
        }

        private bool IsWeekday(DateTime CheckDay)
        {
            if ((int)CheckDay.DayOfWeek > 0 && (int)CheckDay.DayOfWeek < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetLastDayOfMonth()
        {
            DateTime CheckDay = CurrentDay;
            int CurrentMonth = CurrentDay.Month;
            int LastDay = 0;

            while (CurrentMonth == CheckDay.Month)
            {
                LastDay = CheckDay.Day;
                CheckDay = CheckDay.AddDays(1.0);
            }

            return LastDay;
        }

        private DateTime _GetPaydayFromPayPeriodEnd(DateTime CheckDay)
        {
            while (!IsWeekday(CheckDay))
            {
                CheckDay = CheckDay.AddDays(-1.0);
            }

            return CheckDay;
        }

        public DateTime GetEndMonthPayday()
        {
            return _GetPaydayFromPayPeriodEnd(new DateTime(CurrentDay.Year, CurrentDay.Month, GetLastDayOfMonth()));
        }

        public DateTime GetMidMonthPayday()
        {
            return _GetPaydayFromPayPeriodEnd(new DateTime(CurrentDay.Year, CurrentDay.Month, _endOfFirstPayPeriod));
        }

        public DateTime GetFirstPaydayOfNextMonth()
        {
            return _GetPaydayFromPayPeriodEnd(new DateTime(CurrentDay.Year, CurrentDay.Month, _endOfFirstPayPeriod).AddMonths(1));
        }

        public DateTime NextPayday()
        {
            DateTime CheckDay = CurrentDay;
            if (CheckDay < GetMidMonthPayday())
            {
                return GetMidMonthPayday();
            }
            else if (CheckDay < GetEndMonthPayday())
            {
                return GetEndMonthPayday();
            }
            else
            {
                return GetFirstPaydayOfNextMonth();
            }
        }

        public void NextDay(Double advance = 1.0)
        {
            _currentDay = _currentDay.AddDays(advance);            
        }

        public Payday(DateTime theCurrentDay)
        {
            _currentDay = theCurrentDay;
        }

        public Payday()
        {
            _currentDay = DateTime.Now;
        }
    }
}