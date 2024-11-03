using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    [Table("ShiftAddress", Schema = "TPT")]
    public class ShiftAddressEntity : AddressEntity, IAddressEntity
    {
        int IAddressEntity.Id { get => AddressId; }

        string IAddressEntity.AddressType
        {
            get => typeof(ShiftAddressEntity).Name;
        }

        public virtual ShiftEntity? Shift { get; set; }
        string IAddressEntity.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddressEntity.UnitNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddressEntity.StreetNum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddressEntity.StreetName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddressEntity.StreetType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        SuburbEntity IAddressEntity.Suburb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IAddressEntity.City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
