using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Roster.Entities
{
    [Index(nameof(Nickname), IsUnique = true)]
    public abstract partial class Person
    {
        public int Id { get; set; }        
        public string FirstName;        
        public string LastName;        
        public string Nickname;        

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }

        
        public string Gender;        
        public string? Dob;

        #nullable enable        
        [Phone]
        public string? Phone;

        #nullable enable        
        [EmailAddress]
        public string? Email;

        [ForeignKey("AddressId")] // for a shadow property to the Address ID FK
        public virtual Address Address { get; set; }

        
        public string? HighlightColor;

        public Person(string firstName, string lastName, string nickname, string gender)
        {
            Debug.WriteLine("Adding person");

            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
            Gender = gender;
        }

        public Person(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color? highlightColor)
        {            
            if (highlightColor == null) //https://stackoverflow.com/questions/4454336/can-i-specify-a-default-color-parameter-in-c-sharp-4-0
            {
                highlightColor = Color.Black;
            }
            
            Debug.WriteLine("Adding person");
            
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname; 
            Gender = gender;
            Dob = dob;
            Phone = phone;
            Email = email;
            HighlightColor = highlightColor.ToString();
            //_userId = userId;
        }
    }
}