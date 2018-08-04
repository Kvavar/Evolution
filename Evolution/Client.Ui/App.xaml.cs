using System;
using System.Windows;

namespace Client.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            StartupUri = new Uri("View/MainView.xaml", UriKind.Relative);
        }
    }
}
