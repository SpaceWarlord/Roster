using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{

    [Table("ShiftWorker", Schema = "TPT")]
    public partial class ShiftWorker: BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Shift is Required")]
        private Shift _shift;

        public int WorkerId {  get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Worker is Required")]
        private Worker _worker;

        [ObservableProperty]        
        private DateOnly _startDateTime;

        [ObservableProperty]
        private DateOnly _endDateTime;        

        [ObservableProperty]
        private ShiftAddress? _startLocation;

        [ObservableProperty]
        private ShiftAddress? _endLocation;

        public ObservableCollection<Route> Routes { get; set; }

        public ShiftWorker() { }

        public ShiftWorker(Shift shift, Worker worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
        }
    }
}