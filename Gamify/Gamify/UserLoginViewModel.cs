
using Gamify.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using System.Diagnostics;

namespace Gamify
{
    internal class UserLoginViewModel : ViewModelBase
    {
        //  Fields and Accessors
        string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetPropertyAndRaise<string>(ref _userName, value); }
        }

        List<User> _users;
        public List<User> Users
        {
            get{ return _users; }
            set { SetPropertyAndRaise<List<User>>(ref _users, value); }
        }

        private NavigationService navigator;

        public ICommand CreateNewUserCommand { get; }

        //  Constructor
        public UserLoginViewModel(NavigationService navigator)
        {
            Debug.WriteLine("DUDE USERLOGINVIEWMODEL");
            this.navigator = navigator;
            GetUsersAsync();
            CreateNewUserCommand = new Command(CreateNewUser);
            CreateNewUserCommand.Execute(null);
        }

        //  Methods

        private async void GetUsersAsync()
        {
            Debug.WriteLine("Looking for Users");
            Users = await App.Database.GetUsersAsync();
            Debug.WriteLine("Found Users");
        }

        private async void CreateNewUser()
        {
            Debug.WriteLine("CREATING NEW USER DUDE: " + UserName);
            if (string.IsNullOrWhiteSpace(UserName)) return;

            User user = new User
            {
                UserName = UserName,
                XP = 0
            };

            //  FOR NOW: Just add the name to the list and update

            await App.Database.SaveUserAsync(user);
            GetUsersAsync();
            
            //  TODO: Navigate to Quest Page using User in constructor for QuestsViewModel
        }

    }
}