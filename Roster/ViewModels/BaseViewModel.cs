using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.ViewModels
{
    public class BaseViewModel: ObservableObject
    {
        public RosterDBContext context;

        public BaseViewModel()
        {
            context = new RosterDBContext();
        }
    }
}
