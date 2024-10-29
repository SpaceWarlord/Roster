using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public partial class Certificate: BaseModel
    {
        public int Id { get; set; }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate is Required")]
        private string _name;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate Expiry Length is Required")]
        private int _certLength;


        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Certificate Infinite Status is Required")]
        private bool _infinite;
        public Certificate() { }


        public Certificate(string name, int certLength, bool infinite)
        {
            Name = name;
            CertLength = certLength;
            Infinite = infinite;
        }
    }
}
