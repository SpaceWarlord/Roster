using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{

    [Table("ShiftWorker", Schema = "TPT")]
    public partial class ShiftWorkerEntity
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }

        
        [Required(ErrorMessage = "Shift is Required")]
        private ShiftEntity Shift;

        public int WorkerId {  get; set; }

        
        [Required(ErrorMessage = "Worker is Required")]
        public WorkerEntity Worker;

        
        public DateOnly StartDateTime;

        
        public DateOnly EndDateTime;        

        
        public ShiftAddressEntity? StartLocation;

        
        public ShiftAddressEntity? EndLocation;

        public ObservableCollection<RouteEntity> Routes { get; set; }

        public ShiftWorkerEntity() { }

        public ShiftWorkerEntity(ShiftEntity shift, WorkerEntity worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}