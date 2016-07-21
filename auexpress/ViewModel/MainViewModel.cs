using auexpress.Utils;
using auexpress.View;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace auexpress.ViewModel
{
    public class MainViewModel : NotificationObject
    { 

        
        public delegate void ShowWindowsDelegate();
        public event ShowWindowsDelegate ShowSend;

        public delegate void ManageExpressDelegate();
        public event ManageExpressDelegate ManageExpressSend;

        /**
         * 信息录入
         */
        public DelegateCommand ManageExpressCommand { get; set; }

        /// <summary>
        /// 订单处理
        /// </summary>
        public DelegateCommand WaybillProcessingCommand { get; set; }

        /**
         * 触发
         */
        public void TriggerWaybillProcessingSend()
        {
            if (ShowSend != null) {
                ShowSend();
            }
        }

        /**
 * 触发
 */
        public void TriggerManageExpressSend()
        {
            if (ManageExpressSend != null)
            {
                ManageExpressSend();
            }
        }



        public void ManageExpressShow()
        {
            TriggerManageExpressSend();
        }

        public void WaybillProcessingShow(){
            TriggerWaybillProcessingSend();
        }

        public MainViewModel() {
 
            this.WaybillProcessingCommand = new DelegateCommand(new Action(WaybillProcessingShow));
            this.ManageExpressCommand = new DelegateCommand(new Action(ManageExpressShow));
        }


    }
}
