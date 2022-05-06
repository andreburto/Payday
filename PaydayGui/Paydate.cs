using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Payday;

namespace PaydayGui
{
    class Paydate : INotifyPropertyChanged
    {
        private Payday.Payday _payday;
        private DateTime _paydate;

        public DateTime Today
        {
            get
            {
                return _payday.CurrentDay;
            }
        }

        public int DaysToTheNextPayday
        {
            get
            {
                return _payday.DaysToPayday;
            }
        }

        public string DayAndMonthOfNow
        {
            get
            {
                return String.Format("{0:D2}-{1:D2}-{2:D2}", _payday.CurrentDay.Year, _payday.CurrentDay.Month, _payday.CurrentDay.Day);
            }
        }

        public string DayAndMonthOfPay
        {
            get 
            {
                return String.Format("{0:D2}-{1:D2}-{2:D2}", _paydate.Year, _paydate.Month, _paydate.Day);
            }
        }

        public void Next()
        {
            _payday.NextDay();
            _paydate = _payday.NextPayday();
            NotifyPropertyChanged("Today");
            NotifyPropertyChanged("Paydate");
            NotifyPropertyChanged("DaysToTheNextPayday");
            NotifyPropertyChanged("DayAndMonthOfNow");
            NotifyPropertyChanged("DayAndMonthOfPay");
        }

        public Paydate()
        {
            _payday = new Payday.Payday(DateTime.Now);
            _paydate = _payday.NextPayday();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
