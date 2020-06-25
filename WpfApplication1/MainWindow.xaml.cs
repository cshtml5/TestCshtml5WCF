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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client _soapClient = new ServiceReference1.Service1Client();
        ServiceReference2.Service1Client _soapClient3 = new ServiceReference2.Service1Client();

        void ButtonReceiveFaultExceptionWithoutTryCatch(object sender, RoutedEventArgs e)
        {
            _soapClient.ReceiveFaultException();
        }

        void ButtonReceiveFaultExceptionWithTryCatch(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient.ReceiveFaultException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ButtonReceiveServerErrorWithoutTryCatch(object sender, RoutedEventArgs e)
        {
            _soapClient.ReceiveServerInternalErrorException();
        }
        void ButtonReceiveServerErrorWithTryCatch(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient.ReceiveServerInternalErrorException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonReceiveFaultExceptionEventAsync(object sender, RoutedEventArgs e)
        {
            _soapClient3.ReceiveFaultExceptionCompleted += _soapClient3_ReceiveFaultExceptionCompleted;
            _soapClient3.ReceiveFaultExceptionAsync();
        }
        private void _soapClient3_ReceiveFaultExceptionCompleted(object sender, ServiceReference2.ReceiveFaultExceptionCompletedEventArgs e)
        {
            MessageBox.Show(e.Error.Message);
        }
        void ButtonReceiveServerErrorEventAsync(object sender, RoutedEventArgs e)
        {
            _soapClient3.ReceiveServerInternalErrorExceptionCompleted += _soapClient3_ReceiveServerInternalErrorExceptionCompleted;
            _soapClient3.ReceiveServerInternalErrorExceptionAsync();
        }
        private void _soapClient3_ReceiveServerInternalErrorExceptionCompleted(object sender, ServiceReference2.ReceiveServerInternalErrorExceptionCompletedEventArgs e)
        {
            MessageBox.Show(e.Error.Message);
        }
    }
}
