using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    [Table("ClientAddress", Schema = "TPT")]
    public class ClientAddressEntity : AddressEntity, IAddressEntity
    {
        int IAddressEntity.Id { get => AddressId; }

        string IAddressEntity.AddressType
        {
            get => typeof(ClientAddressEntity).Name;
        }

        public virtual ClientEntity? Client { get; set; }
        string IAddressEntity.Name {
            get => typeof(AddressEntity).Name;
            set => Name = value; 
        }
        string IAddressEntity.UnitNum {
            get => typeof(AddressEntity).Name;
            set => throw new NotImplementedException(); 
        }
        string IAddressEntity.StreetNum { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        string IAddressEntity.StreetName { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        string IAddressEntity.StreetType { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        SuburbEntity IAddressEntity.Suburb { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
        string IAddressEntity.City { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        /*
        [Required]
        [Key]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        //public virtual ICollection<Client> Clients { get; } = []; // Optional
        public virtual Address Address { get; set; } = new();                       

        int IAddress.Id { get => AddressId; }



        string IAddress.AddressType
        {
            get => typeof(ClientAddress).Name;
            //set => AddressType = value;
        }            
        
        string IAddress.Name
        {
            get => Address.Name;
            set => Address.Name = value;
        }                

        string IAddress.UnitNum
        {
            get => Address.UnitNum;
            set => Address.UnitNum = value;
        }
        string IAddress.StreetNum
        {
            get => Address.StreetNum;
            set => Address.StreetNum = value;
        }
        string IAddress.StreetName
        {
            get => Address.StreetName;
            set => Address.StreetName = value;
        }

        string IAddress.StreetType
        {
            get => Address.StreetType;
            set => Address.StreetType = value;
        }

        int IAddress.SuburbId
        {
            get => Address.SuburbId;
            set => Address.SuburbId = value;
        }

        Suburb IAddress.Suburb
        {
            get => Address.Suburb;
            set => Address.Suburb = value;
        }
        string IAddress.City
        {
            get => Address.City;
            set => Address.City = value;
        }

        */
    }
}