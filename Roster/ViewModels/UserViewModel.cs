using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roster.Models;
using Microsoft.UI.Xaml;
using ABI.System;
using Roster.ViewModels;

namespace Roster.ViewModels
{
    public partial class UserViewModel : BaseViewModel
    {       

        private User _user = new User();
        public User User => _user;
        
        public ObservableCollection<User> Users;        

        public UserViewModel()
        {            
            Users = new ObservableCollection<User>();
            UpdateUsers(context.Users.ToList());
            Users.CollectionChanged += this.OnCollectionChanged;            
        }

        public void UpdateUsers(List<User> users)
        {
            Users.Clear();
            Debug.WriteLine("TTotal users: " + users.Count);
            foreach (User user in users)
            {
                Debug.WriteLine("User: " + user.Username);
                Users.Add(user);
            }
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("modified collection");
            //e.Action = NotifyCollectionChangedAction.
            if (e.NewItems != null)
            {
                Debug.WriteLine("New items to add");
                foreach (User newItem in e.NewItems)
                {
                    Debug.WriteLine("New User: Id: " + newItem.Id + " Username " + newItem.Username);
                    //ModifiedItems.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    context.Users.Add(newItem);                    
                    //newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
                //context.SaveChanges();
            }

            if (e.OldItems != null)
            {
                foreach (User oldItem in e.OldItems)
                {
                    //ModifiedItems.Add(oldItem);

                    context.Users.Remove(oldItem);
                    Debug.WriteLine("Deleted from db");
                    //oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            context.SaveChanges();
        }

        [RelayCommand]
        private void Login(User user)
        {
            Debug.WriteLine("Called Login");
            if (user != null)
            {
                Debug.WriteLine("Username is " + user.Username);
                Application.Current.Resources["currentUser"] = user;
                //Application.Current.Properties["Timecap"] = timecap;
                //User currentUser = (Application.Current as App)?.CurrentUser as User;
                //ref User currentUser = ref Application.Current;
                //Application.Current
                //(Application.Current as App)?.CurrentUser = user;
                //currentUser = user;
                //Debug.WriteLine("set user to " + (Application.Current as App)?.CurrentUser.Username);
                Window mainWindow = (Application.Current as App)?.MainWindow as Shell;
                mainWindow = new Shell();
                mainWindow.Activate();
                Window loginWindow = (Application.Current as App)?.LoginWindow as LoginWindow;
                loginWindow.Close();
                
            }
            else
            {
                Debug.WriteLine("User was null");
            }
        }

        [RelayCommand]
        private void DeleteUser(User user)
        {
            Users.Remove(user);
        }


        [RelayCommand]
        public void DeleteUser1(object o)
        {
            Debug.WriteLine("Called Delete User");
            if (o != null)
            {
                int id = int.Parse(o.ToString());


                /*
                 * https://stackoverflow.com/questions/2471433/how-to-delete-an-object-by-id-with-entity-framework
                 */
                using (context)
                {
                    try
                    {
                        context.Users.Remove(new User() { Id = id });
                        context.SaveChanges();
                    }
                    catch (System.Exception ex)
                    {
                        if (!context.Users.Any(i => i.Id == id))
                        {
                            Debug.WriteLine("User was not found with Id: " + id);
                            return;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }
            }
        }



        [RelayCommand]
        public void AddUser(object o)
        {
            Debug.WriteLine("Called Add user");
            if (o != null)
            {
                Debug.WriteLine("not null");                
                string username = o as string;
                Debug.WriteLine("string is " + username);
                if (username != String.Empty)
                {
                    User user=new User(username);
                    /*
                    var user = new User()
                    {
                        Username = username,
                    };
                    */
                                      
                    /*
                    if(context.Set<User>().AddIfNotExists(user, x => x.Username == user.Username)==null)
                    {
                        Debug.WriteLine("Error username already exists: " + user.Username);
                    }
                    else
                    {
                        context.SaveChanges();
                    }
                    */

                    var checkUser = from g in context.Users
                                       where g.Username == user.Username                                           
                                            select g;
                    if (checkUser.FirstOrDefault() == null)
                    {
                        Debug.WriteLine("User added: " + user.Username);
                        //context.Users.Add(user);
                        //context.SaveChanges
                        Users.Add(user);
                    }
                    else
                    {
                        Debug.WriteLine("Error username already exists: " + user.Username);
                    }
                    
                    
                    /*
                    using (context)
                    {
                        var user = new User()
                        {                            
                            Username = username,
                        };
                        Users.Add(user);                                                
                    }*/
                }
            }
        }

        [RelayCommand]
        private void ModifyName(object o)
        {
            string oldName = "fred";
            Debug.WriteLine("called modifiy name");
            if (o != null)
            {
                string newUsername = o as string;
                Debug.WriteLine("object value " + newUsername);
                if (newUsername != String.Empty)
                {
                    Debug.WriteLine("New username " + newUsername);
                    for (int i = Users.Count - 1; i >= 0; i--)
                    {
                        Debug.WriteLine("I: " + i + " Username: " + Users[i].Username);
                        if (Users[i].Username == oldName)
                        {
                            Users[i].Username = newUsername;
                            //context.User.Remove(Users[i]);
                            //Users.RemoveAt(i);
                            Debug.WriteLine("Modified " + oldName + " is now " + newUsername);
                            // or
                            // context.Add<Student>(std);

                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Textbox empty");
                }
            }
        }
    }
}
