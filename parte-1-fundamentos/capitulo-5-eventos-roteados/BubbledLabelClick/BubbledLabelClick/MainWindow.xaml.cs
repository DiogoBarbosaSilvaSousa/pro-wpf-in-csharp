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

namespace BubbledLabelClick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int eventCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
            " Sender(Remetente): " + sender.ToString() + "\r\n" +
            " Source(Fonte): " + e.Source + "\r\n" +
            " Original Source(Fonte original): " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;

        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMessages.Items.Clear();
        }
    }
}
