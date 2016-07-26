using auexpress.model;
using auexpress.Service;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            set { 
                printMenu = value;
                this.RaisePropertyChanged("PrintMenu");
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public PrintViewModel() {

            LoadPrint();
        }

        private void LoadPrint() {

           var obj=  recPreInputService.getRecPreInput(AppGlobal.iid, 10, AppGlobal.serch);

           this.PrintMenu = new PrintMenuItemViewModel();
           if (obj.result) {
               printMenu.Express = obj.obj;
               
           }
        }

        public void TriggerBarCode(string barCode) {

            if (barCodeEvent != null) {

                barCodeEvent(barCode);
            }
        }

    }
}
