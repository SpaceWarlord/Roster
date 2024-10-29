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
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using Windows.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.Views.AddressViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddAddressDialog : ContentDialog
    {
        public RosterDBContext context;
        public Address Address { get; } = new();

        public List<Suburb> currentSuburbs = new List<Suburb> { };
        public AddAddressDialog()
        {
            this.InitializeComponent();
            context = new RosterDBContext();
            //currentSuburbs = new List<Suburb>(context.Suburbs.ToList());


            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\street_types.csv");
            Debug.WriteLine("path is " + path);

            using (var reader = new StreamReader(path))
            {
                List<string> street_types = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split('\t');
                        //street_types.Add(values[1]);
                        //StreetTypeComboBox.Items.Add(values[1]);
                        
                        SelectStreetTypeMenuLayout.Items.Add(
                            new MenuFlyoutItem
                            {
                                Text = values[1],
                                //Command = ViewModel.ChangeLanguageCommand,
                                //CommandParameter = language,
                            }
                        );
                    }                    
                }                
            }
        }

        private void SuburbListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuburbListView.SelectedItem != null)
            {
                Address.Suburb = (Suburb)SuburbListView.SelectedItem;
                Debug.WriteLine("selected suburb is " + Address.Suburb.Name);
                Debug.WriteLine("selected client ID IS " + Address.Suburb.Id);
            }
            else
            {
                SuburbListView.SelectedItem = null;
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
