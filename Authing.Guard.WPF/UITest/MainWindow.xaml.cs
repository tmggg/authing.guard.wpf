using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UITest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public bool Change { get; set; }

        public ICommand TestCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            TestCommand = new TestCommand(TempFunc, p => true);
        }

        private void TempFunc(object parameter)
        {
            MessageBox.Show("刷新二维码");
            Change = false;
        }

        private async void Testbtn_OnClick(object sender, RoutedEventArgs e)
        {
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            await TaskEx.Delay(2000);
            Testbtn.IsBusy = Testbtn.IsBusy != true;
            Testbtn.StartCountDown = true;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Change = Change == false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TestCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);

        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public TestCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}