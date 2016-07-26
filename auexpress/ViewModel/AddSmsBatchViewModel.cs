using auexpress.model;
using auexpress.Model;
using auexpress.Service;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auexpress.ViewModel
{
    public class AddSmsBatchViewModel : NotificationObject
    {

        public delegate void MessageDelegate(Boolean isSuccess,string message);

        public event MessageDelegate MessageEvent;

        private SmsBatchService smsBatchService = new SmsBatchService();

        private string batchNumber;

        public string BatchNumber
        {
            get { return batchNumber; }
            set {
                batchNumber = value;
                this.RaisePropertyChanged("BatchNumber");
            }
        }
          
        public DelegateCommand addCommand { get; set; }

        public DelegateCommand<object> messageCommand { get; set; }


        public AddSmsBatchViewModel() {

            this.addCommand = new DelegateCommand(new Action(AddSmsBatch)); 

        }

        /// <summary>
        /// 添加
        /// </summary>
        private void AddSmsBatch() {
            try
            {
                SmsBatch smsBatch = new SmsBatch();
                smsBatch.batchNumber = this.BatchNumber;
                smsBatch.createDate = DateTime.Now.ToString("yyyy-MM-dd");
                smsBatch.createUser = AppGlobal.user.icid;
                var count = smsBatchService.add(smsBatch);
                if (count == 0)
                {

                    TriggerMessage(false, "添加批次号失败，请联系系统管理员！");
                }
                else if (count == 1)
                {
                    TriggerMessage(true, "添加批次号成功！");
                }
                else if (count == 2)
                {
                    TriggerMessage(false, "批次号重复，请重新填写！");
                }
            }
            catch {
                TriggerMessage(false, "网络请求错误。请退出软件重新连接");
            }
        }

        public void TriggerMessage(Boolean isSuccess, string message)
        {

            if (MessageEvent != null) {

                MessageEvent(isSuccess,message);
            }

        }


    }
}
