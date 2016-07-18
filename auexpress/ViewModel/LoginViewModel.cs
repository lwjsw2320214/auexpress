using auexpress.model;
using auexpress.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms; 

namespace auexpress.ViewModel
{
    public class LoginViewModel : NotificationObject
    {

        public delegate void LoginEventDelegate(bool isSuccess, string msg);
        public event LoginEventDelegate LoginSend;
        public delegate void ShowLoadingEventDelegate();
        public event ShowLoadingEventDelegate ShowLoading;

        private String userName;

        public String UserName
        {
            get { return userName; }
            set {
                userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        private String passWord;

        public String PassWord
        {
            get { return passWord; }
            set {
                passWord = value;
                this.RaisePropertyChanged("PassWord");
            }
        }

        public void TriggerLoginSend(bool isSuccess, string msg) {

            if (LoginSend != null) {
                LoginSend(isSuccess, msg); 
            }
        }

        public void ShowLoadingSend() {
            if (ShowLoading != null) {
                ShowLoading();
            }
        }
        
        /**
         * 登录
         */
        public DelegateCommand<object> UserLoginCommand { get; set; }

        private void UserLogin(object inputPassword)
        {
            this.PassWord = ((PasswordBox)inputPassword).Password;

            if (String.IsNullOrEmpty(this.UserName)||String.IsNullOrEmpty(PassWord))
            {
                TriggerLoginSend(false, "用户名和密码不能为空"); 

                return;
            }

            var encryptPassWord = EncryptionCommen.getEncryptString(this.passWord);

            ContentNetWork network = new ContentNetWork();

            Dictionary<string, object> dc = new Dictionary<string, object>();

            dc.Add("username", this.UserName);

            dc.Add("password", encryptPassWord);

            try
            {
                var pageContent = network.getApi("http://127.0.0.1:8080/index", dc);

                LoginPage lp = pageContent.JsonToObject<LoginPage>();

                if (!lp.result) {

                    TriggerLoginSend(lp.result, "用户名或者密码错误！");

                    return;
                }

                AppGlobal.user = lp.obj;
            }
            catch (Exception e) { 

                TriggerLoginSend(false, "网络连接错误！");

                return;
            }
             
            TriggerLoginSend(true, ""); 
        }

        public LoginViewModel() {

            UserLoginCommand = new DelegateCommand<object>(UserLogin); 

        }
 

    }
}
