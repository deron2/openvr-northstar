﻿using MahApps.Metro;
using System;
using System.Windows;

namespace NorthstarLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnExit(object sender, ExitEventArgs e)
        {
            global::Properties.Settings.Default.Save();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled exception:" + e.Exception.Message + "\n" + e.ToString() + "\n\nPlease contact the developer with these details so they can be fixed.", "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //// get the current app style (theme and accent) from the application
            //// you can then use the current theme and custom accent instead set a new theme
            //Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            //// now set the Green accent and dark theme
            //ThemeManager.ChangeAppStyle(Application.Current,
            //                            ThemeManager.GetAccent("Blue"),
            //                            ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1

            ////base.OnStartup(e);
        }
    }
}
