using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;



namespace Roster.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    public partial class UserEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [MinLength(2, ErrorMessage = "Name should be longer than one character")]
        public string Username = string.Empty;

        /*
        [ObservableProperty]
        private ObservableCollection<UserSettings> _userSettings = new ObservableCollection<UserSettings>();
        */

        public UserEntity()
        {

        }        

        public UserEntity(string username)
        {
            Username = username;
        }
    }
}
