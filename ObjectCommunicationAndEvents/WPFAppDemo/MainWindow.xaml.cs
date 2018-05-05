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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void SecondsChangedHandler(object sender, EventArgs e);
        public event SecondsChangedHandler SecondsChanged;

        public delegate void MinutesChangedHandler(int currentMinute);
        public event MinutesChangedHandler MinutesChanged;

        public MainWindow()
        {
            InitializeComponent();
            this.SecondsChanged += OnSecondsChanged;
            this.MinutesChanged += OnMinutesChanged;
        }

        private void OnMinutesChanged(int currentMinute)
        {
            throw new NotImplementedException();
        }

        private void OnSecondsChanged(object sender, EventArgs e)
        {

        }

        private void buttonPrintSeconds_Click(object sender, RoutedEventArgs e)
        {
            labelSeconds.Content = DateTime.Now.Second;
        }


    }
}
