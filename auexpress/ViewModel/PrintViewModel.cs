using auexpress.model;
using auexpress.Service;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace auexpress.ViewModel
{
    public class PrintViewModel : NotificationObject
    {

        private RecPreInputService recPreInputService = new RecPreInputService();

        public delegate void barCodeDelegate(string barCode);
        public event barCodeDelegate barCodeEvent;

        private PrintMenuItemViewModel printMenu;

        public PrintMenuItemViewModel PrintMenu
        {
            get { return printMenu; }
            set
            {
                printMenu = value;
                this.RaisePropertyChanged("PrintMenu");
            }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        private string addressee;

        public string Addressee
        {
            get { return addressee; }
            set
            {
                addressee = value;
                this.RaisePropertyChanged("Addressee");
            }
        }

        /// <summary>
        /// 寄件人
        /// </summary>
        private string theSender;

        public string TheSender
        {
            get { return theSender; }
            set
            {
                theSender = value;
                this.RaisePropertyChanged("TheSender");
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public PrintViewModel()
        {

            LoadPrint();
        }

        private void LoadPrint()
        {

            try
            {
                var obj = recPreInputService.getRecPreInput(AppGlobal.iid, AppGlobal.user.icid, AppGlobal.serch);

                this.PrintMenu = new PrintMenuItemViewModel();
                if (obj.result)
                {
                    this.printMenu.Express = obj.obj;
                    this.printMenu.Express.dsysdate = DateTime.Parse(this.printMenu.Express.dsysdate).ToString("yyyy-MM-dd");
                    this.Addressee = "姓名：" + this.printMenu.Express.creceiver + " " + this.printMenu.Express.cphone + " 地址：" + this.printMenu.Express.caddr;
                    this.TheSender = "姓名：" + AppGlobal.user.csender + " " + AppGlobal.user.cphone + " 地址：" + AppGlobal.user.caddr;
                }

            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }
        }

        public void TriggerBarCode(string barCode)
        {

            if (barCodeEvent != null)
            {

                barCodeEvent(barCode);
            }
        }

    }
}
