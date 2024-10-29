using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class WorkerCertificate: BaseModel
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Worker is Required")]
        private Worker _worker;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate is Required")]
        private Certificate _certificate;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Date Obtained is Required")]
        private DateOnly _dateObtained;

        public WorkerCertificate(Worker worker, Certificate certificate, DateOnly dateObtained)
        {
            Worker = worker;
            Certificate = certificate;
            DateObtained = dateObtained;
        }
    }
}