using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class EmergencyContactEntity : PersonEntity
    {        
        public PersonEntity ContactFor;
        public EmergencyContactEntity(string firstName, string lastName, string nickname, string gender, PersonEntity contactFor) : base(firstName, lastName, nickname, gender)
        {
            ContactFor = contactFor;
        }
    }
}