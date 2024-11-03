﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public class SuburbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }

        public SuburbEntity(string name, string postCode) 
        {
            Name = name;
            PostCode = postCode;
        }
    }
}
