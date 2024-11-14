using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.ViewModels
{
    public partial class ClientXViewModel: PersonViewModel
    {
        [ObservableProperty]
        private byte _riskCategory;

        [ObservableProperty]
        private string? _genderPreference;
        public ClientXViewModel() { }
    }
}
