using Demo.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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

namespace Demo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();

            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.IsAvailable,
                    v => v.searchResultsListBox.Visibility)
                .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                    vm => vm.SearchResults,
                    v => v.searchResultsListBox.ItemsSource)
                .DisposeWith(disposableRegistration);

                this.Bind(ViewModel,
                    vm => vm.SearchTerm,
                    v => v.serachTextBox.Text)
                .DisposeWith(disposableRegistration);
            });
        }
    }
}
