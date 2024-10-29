﻿using CommunityToolkit.Mvvm.ComponentModel;
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

namespace Roster.Models
{
    [Index(nameof(Nickname), IsUnique = true)]
    public abstract partial class Person: BaseModel
    {
        public int Id { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "First Name is Required")]
        private string _firstName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Last Name is Required")]
        private string _lastName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Nickname is Required")]
        private string _nickname;        

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Gender is requred")]
        private string _gender;

        [ObservableProperty]
        private string? _dob;

#nullable enable
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Phone]
        private string? _phone;

#nullable enable
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [EmailAddress]
        private string? _email;

        [ForeignKey("AddressId")] // for a shadow property to the Address ID FK
        public virtual Address Address { get; set; }

        [ObservableProperty]
        private string? _highlightColor;

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