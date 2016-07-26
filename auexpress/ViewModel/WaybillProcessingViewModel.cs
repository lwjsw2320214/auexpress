using auexpress.model;
using auexpress.Service;
using auexpress.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace auexpress.ViewModel
{
    public class WaybillProcessingViewModel : NotificationObject
    {

        private WaybillProcessingService waybillProcessingService = new WaybillProcessingService();
         
        public delegate void EditEventDelegate();

        public event EditEventDelegate EditShow;

        private List<ExpressMenuItemViewModel> expressMenu;
        
        public List<ExpressMenuItemViewModel> ExpressMenu
        {
            get { return expressMenu; }
            set { 
                expressMenu = value;

                this.RaisePropertyChanged("ExpressMenu");
            }
        }

        private int pageCount; 

        public int PageCount
        {
            get { return pageCount; }
            set {
                pageCount = value;
                this.RaisePropertyChanged("PageCount");
            }
        }
         
        private int pageSize; 

        public int PageSize
        {
            get { return pageSize; }
            set { 
                pageSize = value;
                this.RaisePropertyChanged("PageSize");
            }
        }
          
        public DelegateCommand WaybillProcessingCommand { get; set; }

        public DelegateCommand HomeCommand { get; set; }

        public DelegateCommand PreviousCommand { get; set; }

         public DelegateCommand NextCommand { get; set; }

         public DelegateCommand LastCommand { get; set; }

         public DelegateCommand EditCommand { get; set; }

        public WaybillProcessingViewModel() {

            LoadExpressMenu();
            this.HomeCommand = new DelegateCommand(new Action(HomePage));
            this.PreviousCommand = new DelegateCommand(new Action(PreviousPage));
            this.NextCommand = new DelegateCommand(new Action(NextPage));
            this.LastCommand = new DelegateCommand(new Action(LastPage));
            this.EditCommand = new DelegateCommand(new Action(Edit));

            //this.WaybillProcessingCommand = new DelegateCommand(new Action());
        }
         
        /// <summary>
        /// 初始化数据 
        /// </summary>
        private void LoadExpressMenu() {

            try { 
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", AppGlobal.user.icid);
            dc.Add("irid", 0);
            dc.Add("page", 1); 
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var Count = waybillProcessingService.LoadExpressMenu(dc); 
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result) {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
                this.PageCount = Count.pageCount;
                this.PageSize = Count.page;
              }

            
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void HomePage()
        {
            try { 
            this.PageSize = 1;
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", AppGlobal.user.icid);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize); 
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
                this.PageCount = Count.pageCount;
                this.pageSize = Count.page;
            }
                 
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }

        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void PreviousPage()
        {
            try { 

            if (1 >= this.PageSize)
            {
                this.PageSize = 1;
            }
            else if (this.PageSize > 1)
            {

                this.PageSize--;
            }
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", AppGlobal.user.icid);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
                this.PageCount = Count.pageCount;
                this.pageSize = Count.page;
            }

            
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }

        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void NextPage() {
            try { 

            if (this.PageCount <= this.PageSize)
            {
                this.PageSize = this.PageCount;
            }
            else if(this.PageCount>this.PageSize) {

                this.PageSize++;
            }
             
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", AppGlobal.user.icid);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
                this.PageCount = Count.pageCount;
                this.pageSize = Count.page;
            }

            
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }
        }

         /// <summary>
         /// 末页
         /// </summary>
        private void LastPage() {

            try { 
            this.PageSize = this.PageCount;  
            Dictionary<string, object> dc = new Dictionary<string, object>();
            dc.Add("icid", AppGlobal.user.icid);
            dc.Add("irid", 0);
            dc.Add("page", this.PageSize);
            dc.Add("username", AppGlobal.user.mcaccount);
            dc.Add("token", AppGlobal.user.token);
            var Count = waybillProcessingService.GetPage(dc);
            this.ExpressMenu = new List<ExpressMenuItemViewModel>();
            if (Count.result)
            {
                foreach (var item in Count.obj)
                {

                    ExpressMenuItemViewModel mv = new ExpressMenuItemViewModel();

                    mv.Express = item;

                    this.ExpressMenu.Add(mv);
                }
                this.PageCount = Count.pageCount;
                this.pageSize = Count.page;
            }

            
            }
            catch
            {

                MessageBox.Show("网络错误。请退出软件重新连接");
                return;
            }
        }


        /// <summary>
        /// 添加运单事件
        /// </summary>
        public void TriggerEditShow() {

            if (EditShow != null) {
                EditShow();
            }  
        }

        /// <summary>
        /// 开始添加运单
        /// </summary>
        private void Edit() {

            TriggerEditShow();
        } 


    }
}
