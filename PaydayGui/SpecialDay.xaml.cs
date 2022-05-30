using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PaydayGui
{
    /// <summary>
    /// Interaction logic for SpecialDay.xaml
    /// </summary>
    public partial class SpecialDay : Window
    {
        private SpecialDate _sd;

        public SpecialDay()
        {
            InitializeComponent();
            _sd = new SpecialDate();
            this.DataContext = _sd;
        }
    }
}
