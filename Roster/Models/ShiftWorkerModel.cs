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
    public partial class ShiftWorkerModel: BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Shift is Required")]
        private ShiftModel _shift;

        public int WorkerId {  get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Worker is Required")]
        private WorkerModel _worker;

        [ObservableProperty]        
        private DateOnly _startDateTime;

        [ObservableProperty]
        private DateOnly _endDateTime;        

        [ObservableProperty]
        private ShiftAddress? _startLocation;

        [ObservableProperty]
        private ShiftAddress? _endLocation;

        public ObservableCollection<RouteModel> Routes { get; set; }

        public ShiftWorkerModel() { }

        public ShiftWorkerModel(ShiftModel shift, WorkerModel worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
        }
    }
}