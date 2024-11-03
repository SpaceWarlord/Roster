using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Roster.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Roster.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Window, INavigation
    {
        RosterDBContext context;
        public Shell()
        {
            //  Title = App.Title;

            InitializeComponent();

            var appWindow = this.GetAppWindow();
            appWindow.SetIcon("Assets/Beer.ico");

            Root.RequestedTheme = Application.Current.RequestedTheme == ApplicationTheme.Light ? ElementTheme.Light : ElementTheme.Dark;
            //currentUserTextBlock.Text = (Application.Current as App)?.CurrentUser.Username;
            currentUserTextBlock.Text = (Application.Current.Resources["currentUser"] as UserModel).Username;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            Root.RequestedTheme = Root.RequestedTheme == ElementTheme.Light ? ElementTheme.Dark : ElementTheme.Light;

            Ioc.Default.GetService<IMessenger>().Send(new ThemeChangedMessage(Root.ActualTheme));
            */
        }

        /*
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = (Application.Current as App).Settings;
            settings.IsLightTheme = !settings.IsLightTheme;
            (Application.Current as App).SaveSettings();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var settings = (Application.Current as App).Settings;
            Root.RequestedTheme = settings.IsLightTheme ? ElementTheme.Light : ElementTheme.Dark;
        }
        private void Root_ActualThemeChanged(FrameworkElement sender, object args)
        {
            // Theme change refinements (e.g. content dialogs and title bar).
        }
        */

        /*
        public MainWindow()
        {
            this.InitializeComponent();
            context = new RecipeDBContext();
            //userList.DataContext = context;
            GetAllUsers();
        }        

        private void GetAllUsers()
        {
            List<User> users = new List<User>();
            users = context.User.ToList();
            userList.DataContext = users;
            Debug.WriteLine("Total users: " + users.Count);           
            
        }

        
        public IQueryable<User> GetCompanies()
        {
            return DbContext.Set<User>();
        }        

        public static string GetName()
        {
            return "Bill";
        }

        private void getUserButton_Click(object sender, RoutedEventArgs e)
        {
            GetAllUsers();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RecipeDBContext())
            {
                var user = new User()
                {
                    //Id = 1,
                    UserName = "Test",
                };
                context.User.Add(user);

                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
        }
        */
    }
}
