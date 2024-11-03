using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Roster.ViewModels
{
    public partial class AddressViewModel: BaseViewModel
    {                
        public ObservableCollection<AddressModel> Addresses;

        public AddressViewModel()
        {
            Addresses = new ObservableCollection<AddressModel>();
            UpdateAddresses(context.Addresses.ToList());
            Addresses.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();
        }

        public void UpdateAddresses(List<AddressModel> address)
        {
            Addresses.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (AddressModel a in address)
            {
                //Debug.WriteLine("Address: " + c.FirstName + " " + c.LastName);
                Addresses.Add(a);
            }
        }

        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (AddressModel newItem in e.NewItems)
                {
                    //Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    context.Addresses.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (AddressModel oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    context.Addresses.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

        public static AddressModel CreateAddress(string name, string unitNum, string streetNum, string streetName, string streetType, SuburbModel suburb, string city) => new(name, unitNum, streetNum, streetName, streetType, suburb, city);

        [RelayCommand]
        public void AddAddress(AddressModel address)
        {
            Debug.WriteLine("Called Add Address");
            Debug.WriteLine("name is " + address.Name);
            if (address != null)
            {
                AddressModel a = new AddressModel()
                {
                    Name = address.Name,
                    UnitNum = address.UnitNum,
                    StreetNum = address.StreetNum,
                    StreetName = address.StreetName,
                    StreetType = address.StreetType,
                    Suburb = address.Suburb,
                    City = address.City,
                };
                Addresses.Add(a);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Address was null");
            }
        }
    }
}
