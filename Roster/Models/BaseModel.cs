using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public abstract partial class BaseModel: ObservableValidator
    {
        public RosterDBContext context;


        public BaseModel()
        {
            context = new RosterDBContext();
            this.ErrorsChanged += Errors_Changed;
            this.PropertyChanged += Property_Changed;
        }

        ~BaseModel()
        {
            ErrorsChanged -= Errors_Changed;
            PropertyChanged -= Property_Changed;
        }

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in GetErrors(null) select e.ErrorMessage);

        public void Property_Changed(object? sender, PropertyChangedEventArgs e)
        {
            //Debug.WriteLine("Changed: " + e.PropertyName);
            //Debug.WriteLine("errors name " + HasErrors.ToString());
            Debug.WriteLine("Errors is " + Errors);
            if (e.PropertyName != nameof(HasErrors))
            {
                OnPropertyChanged(nameof(HasErrors)); // Update HasErrors on every change, so I can bind to it.
            }
        }

        public void Errors_Changed(object? sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            //Debug.WriteLine("vvv " + nameof(Errors));
            Debug.WriteLine("Errors is " + Errors);
            OnPropertyChanged(nameof(Errors)); // Update Errors on every Error change, so I can bind to it.
        }
    }
}
