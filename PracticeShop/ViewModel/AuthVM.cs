using PracticeShop.DbEnti;
using PracticeShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeShop.ViewModel
{
    public class Auth : BaseVM
    {
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private UserModel user;
        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string userlogin;
        public string UserLogin
        {
            get { return userlogin; }
            set
            {
                userlogin = value;
                User = new UserModel
                {
                    UserLogin = userlogin,
                    UserPassword = this.UserPassword
                };
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string UserPassword
        {
            get { return password; }
            set
            {
                password = value;
                User = new UserModel
                {
                    UserLogin = this.UserLogin,
                    UserPassword = password
                };
                OnPropertyChanged("Password");
            }
        }


        public Auth()
        {
            Users = new ObservableCollection<User>();

            AuthLoad();
        }

        public void AuthLoad()
        {
            

            if (AppData.db.User.Any(u => u.Login == UserLogin && u.Password == UserPassword))
            {
                MainWindow mnWindow = new MainWindow();
                mnWindow.Show();
            }
            if (AppData.db.User.Any(u => u.Login != UserLogin && u.Password == UserPassword))
            {
                var result = MessageBox.Show("Такого аккаунта не существеует, создать?", "Внимание", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                }

            }
            if (AppData.db.User.Any(u => u.Login == UserLogin && u.Password != UserPassword))
            {
                var result = MessageBox.Show("Пароль некорректный!", "Внимание", MessageBoxButton.OK);

            }

        }
    }
}
