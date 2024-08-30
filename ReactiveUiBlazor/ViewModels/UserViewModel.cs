
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Linq;

public class UserViewModel : ReactiveObject
{
    private string _username;
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    private bool _isLoggedIn;
    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set => this.RaiseAndSetIfChanged(ref _isLoggedIn, value);
    }

    public ObservableCollection<User> Users { get; set; }

    public UserViewModel()
    {
        Users = new ObservableCollection<User>
        {
            // Static users for demo purposes
            new User { Username = "admin", Password = "admin123" },
            new User { Username = "user1", Password = "password1" },
            new User { Username = "user2", Password = "password2" }
        };

        // Initialize as not logged in
        IsLoggedIn = false;
    }

    // Method to validate user credentials
    public bool ValidateUser(string username, string password)
    {
        return Users.Any(u => u.Username == username && u.Password == password);
    }

    // Method to handle login
    public bool Login(string username, string password)
    {
        if (ValidateUser(username, password))
        {
            IsLoggedIn = true;
            return true;
        }
        return false;
    }

    // Method to handle logout
    public void Logout()
    {
        Username = string.Empty;
        Password = string.Empty;
        IsLoggedIn = false;
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}






//using ReactiveUI;
//using System.Collections.ObjectModel;
//using System.Reactive;

//namespace ReactiveUiBlazor.ViewModels
//{
//    public class UserViewModel : ReactiveObject
//    {
//        private string _username;
//        public string Username
//        {
//            get => _username;
//            set => this.RaiseAndSetIfChanged(ref _username, value);
//        }

//        private string _password;
//        public string Password
//        {
//            get => _password;
//            set => this.RaiseAndSetIfChanged(ref _password, value);
//        }

//        public ObservableCollection<User> Users { get; set; }

//        public ReactiveCommand<Unit, Unit> AddUserCommand { get; }
//        public ReactiveCommand<Unit, Unit> RemoveUserCommand { get; }

//        public UserViewModel()
//        {
//            Users = new ObservableCollection<User>
//        {
//            // Static users for demo purposes
//            new User { Username = "admin", Password = "admin123" },
//            new User { Username = "user1", Password = "password1" },
//            new User { Username = "user2", Password = "password2" }
//        };

//            // Reactive Command for adding a user
//            AddUserCommand = ReactiveCommand.Create(() =>
//            {
//                var newUser = new User { Username = Username, Password = Password };
//                Users.Add(newUser);
//                Username = string.Empty;
//                Password = string.Empty;
//            });

//            // Reactive Command for removing a user
//            RemoveUserCommand = ReactiveCommand.Create<Unit, Unit>(u =>
//            {
//                if (Users.Count > 0)
//                {
//                    Users.RemoveAt(Users.Count - 1);
//                }
//                return Unit.Default;
//            });
//        }

//        // Method to validate user credentials
//        public bool ValidateUser(string username, string password)
//        {
//            return Users.Any(u => u.Username == username && u.Password == password);
//        }
//    }

//    public class User
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }
//    }
//}

