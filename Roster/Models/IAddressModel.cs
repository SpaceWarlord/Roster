using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public interface IAddressModel
    {
        public int Id { get; }

        int AddressId { get; }
        string AddressType { get; }
        string Name { get; set; }
        string? UnitNum { get; set; }
        string StreetNum { get; set; }
        string StreetName { get; set; }
        string StreetType { get; set; }
        int SuburbId { get; set; }        
        SuburbModel Suburb { get; set; }        
        string City { get; set; }
    }
}
