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
    /// NugetDetailsView.xaml 的交互逻辑
    /// </summary>
    public partial class NugetDetailsView
    {
        public NugetDetailsView()
        {
            InitializeComponent();
            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.IconUrl,
                    v => v.iconImage.Source,
                    url => url == null ? null : new BitmapImage(url))
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                    vm => vm.Title,
                    v => v.titleRun.Text)
                .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                    vm => vm.Description,
                    v => v.descriptionRun.Text)
                .DisposeWith(disposableRegistration);

                this.BindCommand(ViewModel,
                    vm => vm.OpenPage,
                    v => v.openButton)
                .DisposeWith(disposableRegistration);
            });
        }
    }
}
