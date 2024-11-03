using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class EmergencyContactModel : PersonModel
    {
        [ObservableProperty]
        private PersonModel _contactFor;
        public EmergencyContactModel(string firstName, string lastName, string nickname, string gender, PersonModel contactFor) : base(firstName, lastName, nickname, gender)
        {
            ContactFor = contactFor;
        }
    }
}