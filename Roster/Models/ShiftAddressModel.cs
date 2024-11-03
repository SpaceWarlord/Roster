using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    [Table("ShiftAddress", Schema = "TPT")]
    public class ShiftAddress : AddressModel, IAddressModel
    {
        int IAddressModel.Id { get => AddressId; }

        string IAddressModel.AddressType
        {
            get => typeof(ShiftAddress).Name;
        }

        public virtual ShiftModel? Shift { get; set; }
        
    }
}
