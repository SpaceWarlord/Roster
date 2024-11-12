using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class EmergencyContact : Person
    {        
        public Person ContactFor;
        public EmergencyContact(string firstName, string lastName, string nickname, string gender, Person contactFor) : base(firstName, lastName, nickname, gender)
        {
            ContactFor = contactFor;
        }
    }
}