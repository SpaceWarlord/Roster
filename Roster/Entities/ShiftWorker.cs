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
    public partial class ShiftWorker
    {
        [Key]
        public int Id { get; set; }
        public int ShiftId { get; set; }

        
        [Required(ErrorMessage = "Shift is Required")]
        private Shift Shift;

        public int WorkerId {  get; set; }

        
        [Required(ErrorMessage = "Worker is Required")]
        public Worker Worker;

        
        public DateOnly StartDateTime;

        
        public DateOnly EndDateTime;        

        
        public ShiftAddress? StartLocation;

        
        public ShiftAddress? EndLocation;

        public ObservableCollection<Route> Routes { get; set; }

        public ShiftWorker() { }

        public ShiftWorker(Shift shift, Worker worker, DateOnly startDateTime, DateOnly endDateTime)
        {
            Shift = shift;
            Worker = worker;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}