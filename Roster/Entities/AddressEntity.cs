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
    public partial class AddressEntity
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
        public SuburbEntity Suburb;        
        public string City;
        
        public AddressEntity() { }

        public AddressEntity(string name, string? unitNum, string streetNum, string streetName, string streetType, SuburbEntity suburb, string city)
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