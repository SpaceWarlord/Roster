using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class ShiftTask
    {        
        public int ShiftTaskId { get; set; }

        
        [Required(ErrorMessage = "Name is Required")]
        public string Name;

        
        [Required(ErrorMessage = "Description is Required")]
        public string Description;
        public ShiftTask() { }

        public ShiftTask(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
