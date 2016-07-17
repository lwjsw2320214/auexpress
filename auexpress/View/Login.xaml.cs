using auexpress.View;
using auexpress.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;

namespace auexpress.view
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        private LoginViewModel loginViewModel = new LoginViewModel();
        public Login()
        { 
            InitializeComponent();
            this.DataContext = loginViewModel;
            loginViewModel.ShowLoading += new LoginViewModel.ShowLoadingEventDelegate(ShowLoading);
            loginViewModel.LoginSend += new LoginViewModel.LoginEventDelegate(LoginEventShow);
        }

        void ShowLoading() {

            this.loadingBack.Visibility = Visibility.Visible;
            this.loadingImg.Visibility = Visibility.Visible;
        }

        void LoginEventShow(bool isSuccess, string msg) {

            if (!isSuccess)
            {
                this.loadingBack.Visibility = Visibility.Collapsed;
                this.loadingImg.Visibility = Visibility.Collapsed;
                this.ShowMessageAsync("登录失败", msg);
            }
            else {
                this.loadingBack.Visibility = Visibility.Collapsed;
                this.loadingImg.Visibility = Visibility.Collapsed;
                Main main = new Main();
                this.Close();
                main.ShowDialog();
            }
        }
        
    }
}
