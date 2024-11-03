using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Entities
{
    public partial class CertificateEntity
    {
        public int Id { get; set; }        
        public string Name;        
        public int CertLength;        
        public bool Infinite;
        public CertificateEntity() { }


        public CertificateEntity(string name, int certLength, bool infinite)
        {
            Name = name;
            CertLength = certLength;
            Infinite = infinite;
        }
    }
}
