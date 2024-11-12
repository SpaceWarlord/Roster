using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class WorkerCertificate
    {       
        [Required(ErrorMessage = "Worker is Required")]
        public Worker Worker;
        
        [Required(ErrorMessage = "Certificate is Required")]
        public Certificate Certificate;
        
        [Required(ErrorMessage = "Date Obtained is Required")]
        public DateOnly DateObtained;

        public WorkerCertificate(Worker worker, Certificate certificate, DateOnly dateObtained)
        {
            Worker = worker;
            Certificate = certificate;
            DateObtained = dateObtained;
        }
    }
}