using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    [Table("Address", Schema = "TPT")]
    public partial class Address
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; protected set; }        
        public string Name;
        public string? UnitNum;     
        public string StreetNum;        
        public string StreetName;        
        public string StreetType;
        public int SuburbId {  get; set; }        
        public Suburb Suburb;        
        public string City;
        
        public Address() { }

        public Address(string name, string? unitNum, string streetNum, string streetName, string streetType, Suburb suburb, string city)
        {
            Name = name;
            UnitNum = unitNum;
            StreetNum = streetNum;
            StreetName = streetName;
            StreetType = streetType;
            Suburb = suburb;
            City = "Adelaide";
        }
    }
}