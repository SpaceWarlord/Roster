using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using System.Drawing;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roster.Entities
{

    [Table("Client", Schema = "TPT")]
    public partial class ClientEntity : PersonEntity
    {        
        /*
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Home Address is Required")]
        private Address _homeAddress;
        */        

        //public virtual ClientAddress ClientAddress { get; set; }       

        
        public byte RiskCategory;        
        public string? GenderPreference;
        public ObservableCollection<ShiftEntity> Shifts { get; set; }
        public ClientEntity(): base(string.Empty, string.Empty, string.Empty, "", string.Empty, string.Empty, null, Color.Black)
        {
            
        }

        public ClientEntity(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, AddressEntity clientAddress, byte riskCategory, string genderPreference) : base(firstName, lastName, nickname, gender, dob, email, phone, highlightColor)
        {
            Address = clientAddress;
            RiskCategory = riskCategory;
            GenderPreference = genderPreference;
        }

        /*
        public Client(string firstName, string lastName, string nickname, string gender, string dob, string email,  string phone, Color highlightColor, IAddress clientAddress, byte riskCategory, string genderPreference) : base(firstName, lastName, nickname, gender, dob, email, phone, highlightColor)
        {
            ClientAddress = clientAddress as ClientAddress;
            RiskCategory = riskCategory;
            GenderPreference = genderPreference;
        }
        */
    }
}