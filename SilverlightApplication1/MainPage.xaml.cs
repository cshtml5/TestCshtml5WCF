using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client _soapClient = new ServiceReference1.Service1Client();

        void ButtonReceiveFaultExceptionWithoutTryCatch(object sender, RoutedEventArgs e)
        {
            _soapClient.ReceiveFaultExceptionAsync();
        }

        private void _soapClient_ReceiveFaultExceptionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
        }

        void ButtonReceiveFaultExceptionWithTryCatch(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient.ReceiveFaultExceptionCompleted += _soapClient_ReceiveFaultExceptionCompleted;
                _soapClient.ReceiveFaultExceptionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ButtonReceiveServerErrorWithoutTryCatch(object sender, RoutedEventArgs e)
        {
            _soapClient.ReceiveServerInternalErrorExceptionAsync();
        }
        void ButtonReceiveServerErrorWithTryCatch(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient.ReceiveServerInternalErrorExceptionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
