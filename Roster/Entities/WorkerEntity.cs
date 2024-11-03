using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roster.Entities
{

    [Table("Worker", Schema = "TPT")]
    public partial class WorkerEntity: PersonEntity
    {
        public int WorkerId { get; protected set; }                
        private List<CertificateEntity> Certificates;


        public WorkerEntity(): base(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        //bool hasManualHandlingCert = true;

        public WorkerEntity(string firstName, string lastName, string nickname, string gender, string dob, string phone, string email, Color highlightColor) : base(firstName, lastName, nickname, gender, dob, phone, email, highlightColor)
        {           
            
        }
    }
}
