using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class RouteModel: BaseModel
    {
        [Key]
        public int RouteId { get; set; }
        string Name {  get; set; }
        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual AddressModel StartAddress { get; set; }
        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual AddressModel EndAddress { get; set; }
        public float Distance {  get; set; }

        public RouteModel() { }
        public RouteModel(string name, AddressModel startAddress, AddressModel endAddress, float distance)
        {
            Name = name;
            StartAddress = startAddress;
            EndAddress = endAddress;
            Distance = distance;
        }
    }
}