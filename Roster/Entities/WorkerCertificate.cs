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
        public WorkerEntity Worker;
        
        [Required(ErrorMessage = "Certificate is Required")]
        public CertificateEntity Certificate;
        
        [Required(ErrorMessage = "Date Obtained is Required")]
        public DateOnly DateObtained;

        public WorkerCertificate(WorkerEntity worker, CertificateEntity certificate, DateOnly dateObtained)
        {
            Worker = worker;
            Certificate = certificate;
            DateObtained = dateObtained;
        }
    }
}