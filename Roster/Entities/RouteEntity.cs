﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class RouteEntity
    {
        [Key]
        public int RouteId { get; set; }
        public string Name {  get; set; }
        [ForeignKey("StartAddressId")] // Shadow FK
        public virtual AddressEntity StartAddress { get; set; }
        [ForeignKey("EndAddressId")] // Shadow FK
        public virtual AddressEntity EndAddress { get; set; }
        public float Distance {  get; set; }

        public RouteEntity() { }
        public RouteEntity(string name, AddressEntity startAddress, AddressEntity endAddress, float distance)
        {
            Name = name;
            StartAddress = startAddress;
            EndAddress = endAddress;
            Distance = distance;
        }
    }
}