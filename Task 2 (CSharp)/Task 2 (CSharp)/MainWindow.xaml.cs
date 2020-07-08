using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_2__CSharp_.ViewModel;

namespace Task_2__CSharp_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ExchangeRates _exchangeRates;

        public MainWindow()
        {
            InitializeComponent();

            _exchangeRates = new ExchangeRates();
            DataContext = _exchangeRates;

            _exchangeRates.UpdateRatesAsync();
            new Task(UpdateRates).Start(); // run task to periodically update currency rates
        }

        public void UpdateRates()
        {
            while (true)
            {
                Thread.Sleep(1000*60*60); // Update info one time per hour
                _exchangeRates.UpdateRatesAsync();
            }
            
        }
    }
}
