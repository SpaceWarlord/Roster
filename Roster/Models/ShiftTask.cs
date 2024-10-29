using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class ShiftTask: BaseModel
    {
        
        public int ShiftTaskId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Name is Required")]
        private string _name;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Description is Required")]
        private string _description;
        public ShiftTask() { }

        public ShiftTask(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
