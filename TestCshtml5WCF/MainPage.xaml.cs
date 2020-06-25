using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Xml.Serialization;
using TestCshtml5WCF.ServiceReference1;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TestCshtml5WCF
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client _soapClient = new ServiceReference1.Service1Client();

        ServiceReference2.Service1Client _soapClient2 = new ServiceReference2.Service1Client();

        ServiceReference3_EventBasedAsync_NoXmlSerializer.Service1Client _soapClient3 = new ServiceReference3_EventBasedAsync_NoXmlSerializer.Service1Client();

        ServiceReference4_EventBasedAsync_XmlSerializer.Service1Client _soapClient4 = new ServiceReference4_EventBasedAsync_XmlSerializer.Service1Client();

        ServiceReference1.Service1Client _soapClientLost =
        new ServiceReference1.Service1Client(
            new System.ServiceModel.BasicHttpBinding(),
            new System.ServiceModel.EndpointAddress(
                new Uri("http://www.nopeynope.com/Service1.svc")));


        #region Without [XmlSerializerFormat] attribute

        void ButtonRefreshToDos_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem[] todos = _soapClient.GetToDos();
            DataGrid1.ItemsSource = todos;
        }

        async void ButtonRefreshToDosAsync_Click(object sender, RoutedEventArgs e)
        {
            var todos = await _soapClient.GetToDosAsync();
            DataGrid1.ItemsSource = todos; //.Body.GetToDosResult;
        }

        void ButtonAddToDo_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference1.ToDoItem()
            {
                Description = SoapToDoTextBox.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                //Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ToDoImportance.Mid,
                //Tags = new string[] { "tag1", "tag2", "tag3" }
            };
            _soapClient.AddOrUpdateToDo(todo);
            ButtonRefreshToDos_Click(sender, e);
        }

        async void ButtonAddToDoAsync_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference1.ToDoItem()
            {
                Description = SoapToDoTextBox.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ToDoImportance.Mid
            };
            await _soapClient.AddOrUpdateToDoAsync(todo);
            ButtonRefreshToDos_Click(sender, e);
        }

        void ButtonDeleteToDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference1.ToDoItem)
                    {
                        var todo = (ServiceReference1.ToDoItem)DataGrid1.SelectedItem;
                        _soapClient.DeleteToDo(todo);
                        ButtonRefreshToDos_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonDeleteToDoAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference1.ToDoItem)
                    {
                        var todo = (ServiceReference1.ToDoItem)DataGrid1.SelectedItem;
                        await _soapClient.DeleteToDoAsync(todo);
                        ButtonRefreshToDos_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonDeleteAllToDos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                _soapClient.DeleteAllToDos();
                ButtonRefreshToDos_Click(sender, e);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonDeleteAllToDosAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                await _soapClient.DeleteAllToDosAsync();
                ButtonRefreshToDos_Click(sender, e);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonReplaceToDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference1.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference1.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference1.ToDoItem()
                        {
                            Description = SoapToDoTextBox.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ToDoImportance.Mid
                        };
                        _soapClient.ReplaceToDo(toDoItemToReplace, newToDo, true);
                        ButtonRefreshToDos_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonReplaceToDoAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference1.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference1.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference1.ToDoItem()
                        {
                            Description = SoapToDoTextBox.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ToDoImportance.Mid
                        };
                        await _soapClient.ReplaceToDoAsync(toDoItemToReplace, newToDo, true);
                        ButtonRefreshToDos_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = _soapClient.GetTheNumberOfToDos();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetNumberOfToDosAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = await _soapClient.GetTheNumberOfToDosAsync();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDosPlusFive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? result = _soapClient.GetTheNumberOfToDosPlusX(5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetNumberOfToDosPlusFiveAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? result = await _soapClient.GetTheNumberOfToDosPlusXAsync(5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetServerDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime result = _soapClient.GetServerDate();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetServerDateAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime result = await _soapClient.GetServerDateAsync();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonMultiplyNumbers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = _soapClient.MultiplyThreeNumbers(3, 4, 5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonMultiplyNumbersAsync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = await _soapClient.MultiplyThreeNumbersAsync(3, 4, 5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetListOfTags_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                if (DataGrid1.SelectedItem is ServiceReference1.ToDoItem)
                {
                    var todo = (ServiceReference1.ToDoItem)DataGrid1.SelectedItem;
                    if (todo.Tags != null)
                    {
                        string tags = string.Join(", ", todo.Tags);
                        MessageBox.Show("The selected item has the following tags: " + tags);
                    }
                    else
                        MessageBox.Show("The selected item has no tags.");
                }
                else
                    MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
            }
            else
                MessageBox.Show("No item selected");
        }

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

        async void ButtonReceiveFaultExceptionWithoutTryCatchAsync(object sender, RoutedEventArgs e)
        {
            await _soapClient.ReceiveFaultExceptionAsync();
        }
        async void ButtonReceiveFaultExceptionWithTryCatchAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await _soapClient.ReceiveFaultExceptionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        async void ButtonReceiveServerErrorWithoutTryCatchAsync(object sender, RoutedEventArgs e)
        {
            await _soapClient.ReceiveServerInternalErrorExceptionAsync();
        }
        async void ButtonReceiveServerErrorWithTryCatchAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await _soapClient.ReceiveServerInternalErrorExceptionAsync();
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
        private void _soapClient3_ReceiveFaultExceptionCompleted(object sender, ServiceReference3_EventBasedAsync_NoXmlSerializer.ReceiveFaultExceptionCompletedEventArgs e)
        {
            MessageBox.Show(e.Error.Message);
        }
        void ButtonReceiveServerErrorEventAsync(object sender, RoutedEventArgs e)
        {
            _soapClient3.ReceiveServerInternalErrorExceptionCompleted += _soapClient3_ReceiveServerInternalErrorExceptionCompleted;
            _soapClient3.ReceiveServerInternalErrorExceptionAsync();
        }
        private void _soapClient3_ReceiveServerInternalErrorExceptionCompleted(object sender, ServiceReference3_EventBasedAsync_NoXmlSerializer.ReceiveServerInternalErrorExceptionCompletedEventArgs e)
        {
            MessageBox.Show(e.Error.Message);
        }

        void ButtonReceiveUnreachableServerWithoutTryCatch(object sender, RoutedEventArgs e)
        {
            _soapClientLost.ReceiveFaultException();
        }
        void ButtonReceiveUnreachableServerWithTryCatch(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClientLost.ReceiveFaultException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        async void ButtonReceiveUnreachableServerWithoutTryCatchAsync(object sender, RoutedEventArgs e)
        {
            await _soapClientLost.ReceiveFaultExceptionAsync();
        }
        async void ButtonReceiveUnreachableServerWithTryCatchAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await _soapClientLost.ReceiveFaultExceptionAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion




        #region EVENT-BASED ASYNC Without [XmlSerializerFormat] attribute

        void ButtonRefreshToDos3_Click(object sender, RoutedEventArgs e)
        {
            _soapClient3.GetToDosCompleted += (s, e2) => { DataGrid1.ItemsSource = e2.Result; };
            _soapClient3.GetToDosAsync();
        }

        void ButtonAddToDo3_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem()
            {
                Description = SoapToDoTextBox.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoImportance.Mid
            };
            _soapClient3.AddOrUpdateToDoCompleted += (s, e2) => { ButtonRefreshToDos3_Click(s, null); };
            _soapClient3.AddOrUpdateToDoAsync(todo);
        }

        void ButtonDeleteToDo3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem)
                    {
                        var todo = (ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem)DataGrid1.SelectedItem;
                        _soapClient3.DeleteToDoCompleted += (s, e2) => { DataGrid1.SelectedItem = null; ButtonRefreshToDos3_Click(s, null); };
                        _soapClient3.DeleteToDoAsync(todo);
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonDeleteAllToDos3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                _soapClient3.DeleteAllToDosCompleted += (s, e2) => { ButtonRefreshToDos3_Click(s, null); };
                _soapClient3.DeleteAllToDosAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonReplaceToDo3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoItem()
                        {
                            Description = SoapToDoTextBox.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ServiceReference3_EventBasedAsync_NoXmlSerializer.ToDoImportance.Mid
                        };
                        _soapClient3.ReplaceToDoCompleted += (s, e2) => { DataGrid1.SelectedItem = null; ButtonRefreshToDos3_Click(s, null); };
                        _soapClient3.ReplaceToDoAsync(toDoItemToReplace, newToDo, true);
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDos3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient3.GetTheNumberOfToDosCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient3.GetTheNumberOfToDosAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDosPlusFive3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient3.GetTheNumberOfToDosPlusXCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient3.GetTheNumberOfToDosPlusXAsync(5);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetServerDate3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient3.GetServerDateCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient3.GetServerDateAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonMultiplyNumbers3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient3.MultiplyThreeNumbersCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient3.MultiplyThreeNumbersAsync(3, 4, 5);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        #endregion




        #region With [XmlSerializerFormat] attribute

        void ButtonRefreshToDos2_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference2.ToDoItem[] todos = _soapClient2.GetToDos();
            DataGrid1.ItemsSource = todos;
        }

        async void ButtonRefreshToDosAsync2_Click(object sender, RoutedEventArgs e)
        {
            var todos = await _soapClient2.GetToDosAsync();
            DataGrid1.ItemsSource = todos.Body.GetToDosResult;
        }

        void ButtonAddToDo2_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference2.ToDoItem()
            {
                Description = SoapToDoTextBox2.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ServiceReference2.ToDoImportance.Mid
            };
            _soapClient2.AddOrUpdateToDo(todo);
            ButtonRefreshToDos2_Click(sender, e);
        }

        async void ButtonAddToDoAsync2_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference2.ToDoItem()
            {
                Description = SoapToDoTextBox2.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ServiceReference2.ToDoImportance.Mid
            };
            await _soapClient2.AddOrUpdateToDoAsync(todo);
            ButtonRefreshToDos2_Click(sender, e);
        }

        void ButtonDeleteToDo2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference2.ToDoItem)
                    {
                        var todo = (ServiceReference2.ToDoItem)DataGrid1.SelectedItem;
                        _soapClient2.DeleteToDo(todo);
                        ButtonRefreshToDos2_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonDeleteToDoAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference2.ToDoItem)
                    {
                        var todo = (ServiceReference2.ToDoItem)DataGrid1.SelectedItem;
                        await _soapClient2.DeleteToDoAsync(todo);
                        ButtonRefreshToDos2_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonDeleteAllToDos2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                _soapClient2.DeleteAllToDos();
                ButtonRefreshToDos2_Click(sender, e);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonDeleteAllToDosAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                await _soapClient2.DeleteAllToDosAsync();
                ButtonRefreshToDos2_Click(sender, e);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonReplaceToDo2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference2.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference2.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference2.ToDoItem()
                        {
                            Description = SoapToDoTextBox2.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ServiceReference2.ToDoImportance.Mid
                        };
                        _soapClient2.ReplaceToDo(toDoItemToReplace, newToDo, true);
                        ButtonRefreshToDos2_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonReplaceToDoAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference2.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference2.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference2.ToDoItem()
                        {
                            Description = SoapToDoTextBox2.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ServiceReference2.ToDoImportance.Mid
                        };
                        await _soapClient2.ReplaceToDoAsync(toDoItemToReplace, newToDo, true);
                        ButtonRefreshToDos2_Click(sender, e);
                        DataGrid1.SelectedItem = null;
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDos2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = _soapClient2.GetTheNumberOfToDos();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetNumberOfToDosAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = await _soapClient2.GetTheNumberOfToDosAsync();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDosPlusFive2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? result = _soapClient2.GetTheNumberOfToDosPlusX(5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetNumberOfToDosPlusFiveAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? result = await _soapClient2.GetTheNumberOfToDosPlusXAsync(5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetServerDate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime result = _soapClient2.GetServerDate();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonGetServerDateAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime result = await _soapClient2.GetServerDateAsync();
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonMultiplyNumbers2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = _soapClient2.MultiplyThreeNumbers(3, 4, 5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        async void ButtonMultiplyNumbersAsync2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double result = await _soapClient2.MultiplyThreeNumbersAsync(3, 4, 5);
                MessageBox.Show(result.ToString());
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        #endregion




        #region EVENT-BASED ASYNC With [XmlSerializerFormat] attribute

        void ButtonRefreshToDos4_Click(object sender, RoutedEventArgs e)
        {
            _soapClient4.GetToDosCompleted += (s, e2) => { DataGrid1.ItemsSource = e2.Result; };
            _soapClient4.GetToDosAsync();
        }

        void ButtonAddToDo4_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem()
            {
                Description = SoapToDoTextBox.Text,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Bytes = new byte[] { 255, 127, 0, 127, 255 },
                NullableTest1 = null,
                NullableTest2 = 5,
                NullableTest3 = null,
                NullableTest4 = DateTime.Now,
                CharValue = 'c',
                Importance = ServiceReference4_EventBasedAsync_XmlSerializer.ToDoImportance.Mid
            };
            _soapClient4.AddOrUpdateToDoCompleted += (s, e2) => { ButtonRefreshToDos4_Click(s, null); };
            _soapClient4.AddOrUpdateToDoAsync(todo);
        }

        void ButtonDeleteToDo4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem)
                    {
                        var todo = (ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem)DataGrid1.SelectedItem;
                        _soapClient4.DeleteToDoCompleted += (s, e2) => { DataGrid1.SelectedItem = null; ButtonRefreshToDos4_Click(s, null); };
                        _soapClient4.DeleteToDoAsync(todo);
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonDeleteAllToDos4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGrid1.SelectedItem = null;
                _soapClient4.DeleteAllToDosCompleted += (s, e2) => { ButtonRefreshToDos4_Click(s, null); };
                _soapClient4.DeleteAllToDosAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonReplaceToDo4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid1.SelectedItem != null)
                {
                    if (DataGrid1.SelectedItem is ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem)
                    {
                        var toDoItemToReplace = (ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem)DataGrid1.SelectedItem;
                        var newToDo = new ServiceReference4_EventBasedAsync_XmlSerializer.ToDoItem()
                        {
                            Description = SoapToDoTextBox.Text,
                            Id = Guid.NewGuid(),
                            CreationDate = DateTime.Now,
                            Bytes = new byte[] { 255, 127, 0, 127, 255 },
                            NullableTest1 = null,
                            NullableTest2 = 5,
                            NullableTest3 = null,
                            NullableTest4 = DateTime.Now,
                            CharValue = 'c',
                            Importance = ServiceReference4_EventBasedAsync_XmlSerializer.ToDoImportance.Mid
                        };
                        _soapClient4.ReplaceToDoCompleted += (s, e2) => { DataGrid1.SelectedItem = null; ButtonRefreshToDos4_Click(s, null); };
                        _soapClient4.ReplaceToDoAsync(toDoItemToReplace, newToDo, true);
                    }
                    else
                        MessageBox.Show("Please select an item that was created using the 'Create' button located in the same column as the button that you just pressed.");
                }
                else
                    MessageBox.Show("No item selected");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information such as "Item not found":
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDos4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient4.GetTheNumberOfToDosCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient4.GetTheNumberOfToDosAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetNumberOfToDosPlusFive4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient4.GetTheNumberOfToDosPlusXCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient4.GetTheNumberOfToDosPlusXAsync(5);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonGetServerDate4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient4.GetServerDateCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient4.GetServerDateAsync();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        void ButtonMultiplyNumbers4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _soapClient4.MultiplyThreeNumbersCompleted += (s, e2) => { MessageBox.Show(e2.Result.ToString()); };
                _soapClient4.MultiplyThreeNumbersAsync(3, 4, 5);
            }
            catch (System.ServiceModel.FaultException ex)
            {
                // Fault exceptions allow the server to pass information:
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


    }
}
