using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class ShiftTaskModel: BaseModel
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
        public ShiftTaskModel() { }

        public ShiftTaskModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
