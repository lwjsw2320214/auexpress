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

        //
        public delegate void ShowWindowsDelegate(PapgeEnum papgeEnum);
        public event ShowWindowsDelegate ShowSend;

        /**
         * 信息录入
         */
        public DelegateCommand InformationImportCommand { get; set; }

        /// <summary>
        /// 订单处理
        /// </summary>
        public DelegateCommand WaybillProcessingCommand { get; set; }

        /**
         * 触发事件
         */
        public void TriggerSend(PapgeEnum papgeEnum)
        {
            if (ShowSend != null) {
                ShowSend(papgeEnum);
            }
        }


        public void InformationImportShow() {
            TriggerSend(PapgeEnum.InformationImport);
        }

        public void WaybillProcessingShow(){
            TriggerSend(PapgeEnum.WaybillProcessing);
        }

        public MainViewModel() {
 
            this.WaybillProcessingCommand = new DelegateCommand(new Action(WaybillProcessingShow));
        }


    }
}
