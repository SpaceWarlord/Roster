using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Roster.Models;
using System.Collections.Specialized;
using System.Drawing;

namespace Roster.ViewModels
{
    public partial class ClientViewModel: BaseViewModel
    {        
        public ObservableCollection<ClientXViewModel> Clients;

        public ClientViewModel()
        {            
            Clients = new ObservableCollection<ClientXViewModel>();            
            UpdateClients(context.Clients.ToList());
            Clients.CollectionChanged += this.OnCollectionChanged;
            //Categories = context.IngredientCategories.Where(p => p.ParentId != null).ToList();            
        }

        public void UpdateClients(List<ClientXViewModel> client)
        {           
            Clients.Clear();
            //Debug.WriteLine("TTotal users: " + users.Count);
            foreach (ClientXViewModel c in client)
            {
                Debug.WriteLine("Client: " + c.FirstName + " " + c.LastName);
                Clients.Add(c);
            }            
        }

        void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (ClientModel newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " First Name " + newItem.FirstName);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    context.Clients.Add(newItem);
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (ClientModel oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    context.Clients.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

        //public static Client CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, IAddress address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);
        public static ClientXViewModel CreateClient(string firstName, string lastName, string nickname, string gender, string dob, string email, string phone, Color highlightColor, AddressModel address, byte riskCategory, string genderPreference) => new(firstName, lastName, nickname, gender, dob, email, phone, highlightColor, address, riskCategory, genderPreference);

        [RelayCommand]
        public void AddClient(ClientXViewModel client)
        {
            Debug.WriteLine("Called Add Client");
            Debug.WriteLine("name is " + client.FullName);
            if (client != null)
            {
                ClientModel c = new ClientModel()
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    FullName = client.FullName,
                    Nickname = client.Nickname,      
                    Gender = client.Gender,
                    Dob = client.Dob,
                    GenderPreference = client.GenderPreference,
                    Email = client.Email,
                    Phone = client.Phone,
                    HighlightColor = client.HighlightColor,                                      
                };
                Clients.Add(c);
                //i.Name = string.Empty;
                //i.RemoveErrors();

            }
            else
            {
                Debug.WriteLine("Error: Client was null");
            }
        }
    }
}
