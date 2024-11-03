using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.Models;
using Roster.Views.ClientViews;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.Views.ClientViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddClientDialog : ContentDialog
    {
        public ClientModel Client { get; } = new();
        public AddClientDialog()
        {
            this.InitializeComponent();
            Client.FullName = string.Empty;
            Client.Gender = "M";
            Client.GenderPreference = string.Empty;
            Client.Phone = "555555";
        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadioButton radioButton = gender.SelectedItem as RadioButton;
            if (radioButton != null)
            {
                Debug.WriteLine("Gender set to: " + radioButton.Content);
            }
            
        }
    }

    public class GenderConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((string)parameter == (string)value);
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? parameter : null;
        }
    }
}
